using System;
using System.Windows.Forms;
using System.Xml;
using System.ComponentModel;
using LiveSplit.Model;
using LiveSplit.TimeFormatters;
using System.Collections.Generic;
using LiveSplit.CatchTheRun;
using LiveSplit.Options;
using System.Net;

namespace LiveSplit.UI.Components
{
    public partial class CatchTheRunSettings : UserControl
    {
        private const int SPLIT_NAME_INDEX = 0;
        private const int SPLIT_TIME_INDEX = 1;
        private const int THRESHOLD_INDEX = 2;
        private const int BROWSER_EMULATION_PREFERRED_VALUE = 11001;
        private const string REGISTER_CATEGORY_BUTTON_TEXT = "Register Category";
        private const string UNREGISTER_CATEGORY_BUTTON_TEXT = "Unregister Category";

        private IRun Run { get; set; }

        internal List<Threshold> Thresholds { get; set; }
        internal string NotificationMessage { get; set; }
        internal bool ShowTriggerIndicator { get; set; }

        internal CtrApiClient ApiClient { get; set; }

        internal bool IsLoggedIn
        {
            get { return Credentials.TwitchUsername != null && Credentials.ProducerKey != null; }
        }
        
        internal bool IsCategoryRegistered
        {
            get { return Xml.ReadIsRegistered(Run.FilePath); }
        }

        private BindingList<Threshold> ThresholdsDataSource { get; set; }

        private string CurrentlyEditingCellInitialValue { get; set; }
        private int BrowserEmulationInitialValue { get; set; }

        public CatchTheRunSettings(LiveSplitState state)
        {
            Run = state.Run;
            Thresholds = Xml.ReadThresholds(Run.FilePath);
            ThresholdsDataSource = new BindingList<Threshold>(Thresholds);
            ApiClient = new CtrApiClient();

            InitializeComponent();

            SetAuthenticationControlsState();
            SetIsCategoryRegisteredControlsState();
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
            try
            {
                ModifyBrowserEmulationKey(BROWSER_EMULATION_PREFERRED_VALUE, out int initial);
                BrowserEmulationInitialValue = initial;

                var form = new TwitchOAuthForm();
                form.FormClosing += TwitchOAuthForm_FormClosing;
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(this, $"An error occurred during Twitch login.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetAuthenticationControlsState();
            }
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(this, "Your credentials will be deleted. Log out?", "Verify Logout", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                try
                {
                    Credentials.DeleteAllCredentials();
                    SetAuthenticationControlsState();
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                    MessageBox.Show(this, $"An error occurred attempting to delete credentials.", "Logout Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void getUpdatedUsernameButton_Click(object sender, EventArgs e)
        {
            try
            {
                var response = await ApiClient.GetTwitchUsername(Credentials.ProducerKey);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var username = await response.Content.ReadAsStringAsync();
                    if (username != Credentials.TwitchUsername)
                    {
                        Credentials.TwitchUsername = username;
                        MessageBox.Show(this, $"Detected changed Twitch username: {username}. Stored credentials updated.", "Changed Username Detected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (username == Credentials.TwitchUsername)
                        MessageBox.Show(this, "Current Twitch username matches the stored credentials. No changes made.", "Same Username Detected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Log.Error(await response.Content.ReadAsStringAsync());
                    MessageBox.Show(this, $"An error occurred getting updated Twitch username.", "Twitch Username Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(this, $"An error occurred getting updated Twitch username.", "Twitch Username Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetAuthenticationControlsState();
            }
        }

        private void TwitchOAuthForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ModifyBrowserEmulationKey(BrowserEmulationInitialValue, out int _);
            SetAuthenticationControlsState();
        }

        private void runGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < Run.Count && e.ColumnIndex == SPLIT_TIME_INDEX)
                e.Value = new ShortTimeFormatter().Format(Run[e.RowIndex].PersonalBestSplitTime[TimingMethod.RealTime]);
        }

        private void runGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex != THRESHOLD_INDEX)
                return;

            var cell = runGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var value = (string)cell.Value;
            CurrentlyEditingCellInitialValue = value;
        }

        private void runGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (runGrid.SelectedCells.Count == 1 && (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back) && runGrid.SelectedCells[0].ColumnIndex == THRESHOLD_INDEX)
            {
                if (runGrid.SelectedCells[0].Value != null && (string)runGrid.SelectedCells[0].Value != "")
                    saveThresholdsButton.Enabled = true;

                runGrid.SelectedCells[0].Value = null;
            }
        }

        private void runGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != THRESHOLD_INDEX)
                return;

            var cell = runGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var value = (string)cell.Value;

            if (IsThresholdInputValid(value))
            {
                if ((string)cell.Value != CurrentlyEditingCellInitialValue)
                    saveThresholdsButton.Enabled = true;
            }
            else
                cell.Value = CurrentlyEditingCellInitialValue;
        }

        private void saveThresholdsButton_Click(object sender, EventArgs e)
        {
            try
            {
                Xml.WriteThresholds(Run.FilePath, ConvertDataRowsToDictionary(runGrid.Rows));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(this, $"An error occurred saving threshold values.", "Error Saving Thresholds", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void registerCategoryButton_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == REGISTER_CATEGORY_BUTTON_TEXT)
            {
                try
                {
                    Xml.WriteIsRegistered(Run.FilePath, true);
                    var cmd = new RegisterProducerCategoryCommand() { Producer = Credentials.TwitchUsername, Game = Run.GameName, Category = Run.CategoryName };
                    var response = await ApiClient.RegisterProducerCategory(Credentials.ProducerKey, cmd);
                    if (response.StatusCode == HttpStatusCode.OK)
                        MessageBox.Show(this, $"Successfully registered category: {Run.GameName} - {Run.CategoryName}.", "Category Registered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        Xml.WriteIsRegistered(Run.FilePath, false);
                        Log.Error(await response.Content.ReadAsStringAsync());
                        MessageBox.Show(this, $"An error occurred registering category: {Run.GameName} - {Run.CategoryName}.", "Category Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                    Xml.WriteIsRegistered(Run.FilePath, false);
                    MessageBox.Show(this, $"An error occurred registering category: {Run.GameName} - {Run.CategoryName}.", "Category Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (((Button)sender).Text == UNREGISTER_CATEGORY_BUTTON_TEXT)
            {
                try
                {
                    Xml.WriteIsRegistered(Run.FilePath, false);
                    var cmd = new UnregisterProducerCategoryCommand() { Producer = Credentials.TwitchUsername, Game = Run.GameName, Category = Run.CategoryName };
                    var response = await ApiClient.UnregisterProducerCategory(Credentials.ProducerKey, cmd);
                    if (response.StatusCode == HttpStatusCode.OK)
                        MessageBox.Show(this, $"Successfully unregistered category: {Run.GameName} - {Run.CategoryName}.", "Category Unregistered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        Xml.WriteIsRegistered(Run.FilePath, true);
                        Log.Error(await response.Content.ReadAsStringAsync());
                        MessageBox.Show(this, $"An error occurred unregistering category: {Run.GameName} - {Run.CategoryName}.", "Category Unregistration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                    Xml.WriteIsRegistered(Run.FilePath, false);
                    MessageBox.Show(this, $"An error occurred unregistering category: {Run.GameName} - {Run.CategoryName}.", "Category Unregistration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            SetIsCategoryRegisteredControlsState();
        }

        private Dictionary<string, string> ConvertDataRowsToDictionary(DataGridViewRowCollection rows)
        {
            var result = new Dictionary<string, string>();

            foreach (DataGridViewRow row in rows)
            {
                var splitName = row.Cells[SPLIT_NAME_INDEX].Value as string;
                var thresholdValue = row.Cells[THRESHOLD_INDEX].Value as string;

                if (thresholdValue == null)
                    thresholdValue = "";

                result.Add(splitName, thresholdValue);
            }

            return result;
        }

        private bool IsThresholdInputValid(string input)
        {
            if (input == null || input == "")
                return false;
            if (input[0] == '+' || input[0] == '-')
                return Double.TryParse(input.Substring(1), out double _);
            else
                return false;
        }

        private void ModifyBrowserEmulationKey(int newValue, out int initialValue)
        {
            using (var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true))
            {
                var appName = System.IO.Path.GetFileName(Application.ExecutablePath);
                initialValue = (int)key.GetValue(appName);
                key.SetValue(appName, newValue, Microsoft.Win32.RegistryValueKind.DWord);
                key.Close();
            }
        }

        private void SetAuthenticationControlsState()
        {
            if (IsLoggedIn)
            {
                loggedInStatusLabel.Text = $"Logged In: {Credentials.TwitchUsername}";
                logIntoTwitchButton.Enabled = false;
                getUpdatedUsernameButton.Enabled = true;
                logOutButton.Enabled = true;
            }
            else
            {
                loggedInStatusLabel.Text = "Not Logged In";
                logIntoTwitchButton.Enabled = true;
                getUpdatedUsernameButton.Enabled = false;
                logOutButton.Enabled = false;
            }
        }

        private void SetIsCategoryRegisteredControlsState()
        {
            if (IsCategoryRegistered)
                registerCategoryButton.Text = UNREGISTER_CATEGORY_BUTTON_TEXT;
            else
                registerCategoryButton.Text = REGISTER_CATEGORY_BUTTON_TEXT;
        }
    }
}
