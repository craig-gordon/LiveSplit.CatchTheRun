using System;
using System.Windows.Forms;
using System.Xml;
using System.ComponentModel;
using LiveSplit.Model;
using LiveSplit.TimeFormatters;
using System.Collections.Generic;
using LiveSplit.CatchTheRun;

namespace LiveSplit.UI.Components
{
    public partial class CatchTheRunSettings : UserControl
    {
        private IRun Run { get; set; }

        internal List<Threshold> Thresholds { get; set; }
        internal string NotificationMessage { get; set; }
        internal bool ShowTriggerIndicator { get; set; }

        internal CtrApiClient ApiClient { get; set; }

        internal bool IsLoggedIn
        {
            get { return Credentials.TwitchUsername != null && Credentials.ProducerKey != null; }
        }

        private BindingList<Threshold> ThresholdsDataSource { get; set; }

        private string CurrentlyEditingCellInitialValue { get; set; }
        private int BrowserEmulationInitialValue { get; set; }

        public CatchTheRunSettings(LiveSplitState state)
        {
            Run = state.Run;
            ApiClient = new CtrApiClient();
            Thresholds = Xml.ReadThresholds(Run.FilePath);
            ThresholdsDataSource = new BindingList<Threshold>(Thresholds);

            InitializeComponent();

            SetAuthenticationControlsState();
            runGrid.DataSource = ThresholdsDataSource;
            runGrid.CellFormatting += runGrid_CellFormatting;
            runGrid.CellBeginEdit += runGrid_CellBeginEdit;
            runGrid.KeyDown += runGrid_KeyDown;
            runGrid.CellEndEdit += runGrid_CellEndEdit;
            saveThresholdsButton.Enabled = false;
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            var parent = document.CreateElement("Settings");
            CreateSettingsNode(document, parent);
            return parent;
        }

        private int CreateSettingsNode(XmlDocument document, XmlElement parent)
        {
            return SettingsHelper.CreateSetting(document, parent, "NotificationMessage", NotificationMessage) ^
            SettingsHelper.CreateSetting(document, parent, "ShowTriggerIndicator", ShowTriggerIndicator);
        }

        public void SetSettings(XmlNode settings)
        {
            NotificationMessage = SettingsHelper.ParseString(settings["NotificationMessage"]);
            ShowTriggerIndicator = SettingsHelper.ParseBool(settings["ShowTriggerIndicator"]);
        }

        private void logIntoTwitchButton_Click(object sender, EventArgs e)
        {
            Util.ModifyBrowserEmulationKey(Util.BROWSER_EMULATION_PREFERRED_VALUE, out int initial);
            BrowserEmulationInitialValue = initial;

            var form = new TwitchOAuthForm();
            form.FormClosing += TwitchOAuthForm_FormClosing;
            form.ShowDialog();
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(this, "Your credentials will be deleted. Log out?", "Verify Logout", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Credentials.DeleteAllCredentials();
                SetAuthenticationControlsState();
            }
        }

        private async void detectChangedUsernameButton_Click(object sender, EventArgs e)
        {
            var username = await ApiClient.GetTwitchUsername(Credentials.ProducerKey);
            if (username != Credentials.TwitchUsername)
            {
                Credentials.TwitchUsername = username;
                SetAuthenticationControlsState();
                MessageBox.Show(this, $"Detected changed Twitch username: {username}. Stored credentials updated.", "Changed Username Detected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (username == Credentials.TwitchUsername)
            {
                MessageBox.Show(this, "Current Twitch username matches the stored credentials. No changes made.", "Same Username Detected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TwitchOAuthForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Util.ModifyBrowserEmulationKey(BrowserEmulationInitialValue, out int _);
            SetAuthenticationControlsState();
        }

        private void runGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < Run.Count && e.ColumnIndex == Util.SPLIT_TIME_INDEX)
                e.Value = new ShortTimeFormatter().Format(Run[e.RowIndex].PersonalBestSplitTime[TimingMethod.RealTime]);
        }

        private void runGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex != Util.THRESHOLD_INDEX)
                return;

            var cell = runGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var value = (string)cell.Value;
            CurrentlyEditingCellInitialValue = value;
        }

        private void runGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (runGrid.SelectedCells.Count == 1 && (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back) && runGrid.SelectedCells[0].ColumnIndex == Util.THRESHOLD_INDEX)
            {
                if (runGrid.SelectedCells[0].Value != null && (string)runGrid.SelectedCells[0].Value != "")
                    saveThresholdsButton.Enabled = true;

                runGrid.SelectedCells[0].Value = null;
            }
        }

        private void runGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != Util.THRESHOLD_INDEX)
                return;

            var cell = runGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var value = (string)cell.Value;

            if (Util.IsThresholdInputValid(value))
            {
                if ((string)cell.Value != CurrentlyEditingCellInitialValue)
                    saveThresholdsButton.Enabled = true;
            }
            else
                cell.Value = CurrentlyEditingCellInitialValue;
        }

        private void saveThresholdsButton_Click(object sender, EventArgs e)
        {
            var success = Xml.WriteThresholds(Run.FilePath, Util.ConvertDataRowsToDictionary(runGrid.Rows), out string error);
        }

        private async void registerCategoryButton_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "Register Category")
            {
                var cmd = new RegisterProducerCategoryCommand() { Producer = Credentials.TwitchUsername, Game = Run.GameName, Category = Run.CategoryName };
                bool success = await ApiClient.RegisterProducerCategory(Credentials.ProducerKey, cmd);
                if (success)
                    MessageBox.Show(this, $"Successfully registered category: {Run.GameName} - {Run.CategoryName}.", "Category Registered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show(this, $"An error occurred while registering category: {Run.GameName} - {Run.CategoryName}. Please try again later.", "Error Registering Category", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (((Button)sender).Text == "Unregister Category")
            {
                var cmd = new UnregisterProducerCategoryCommand() { Producer = Credentials.TwitchUsername, Game = Run.GameName, Category = Run.CategoryName };
                bool success = await ApiClient.UnregisterProducerCategory(Credentials.ProducerKey, cmd);
                if (success)
                    MessageBox.Show(this, $"Successfully unregistered category: {Run.GameName} - {Run.CategoryName}.", "Category Unregistered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show(this, $"An error occurred while unregistering category: {Run.GameName} - {Run.CategoryName}. Please try again later.", "Error Unregistering Category", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetAuthenticationControlsState()
        {
            if (IsLoggedIn)
            {
                loggedInStatusLabel.Text = $"Logged In: {Credentials.TwitchUsername}";
                logIntoTwitchButton.Enabled = false;
                detectChangedUsernameButton.Enabled = true;
                logOutButton.Enabled = true;
            }
            else
            {
                loggedInStatusLabel.Text = "Not Logged In";
                logIntoTwitchButton.Enabled = true;
                detectChangedUsernameButton.Enabled = false;
                logOutButton.Enabled = false;
            }
        }

        private void SetCategoryRegisteredControlsState()
        {
        }
    }
}
