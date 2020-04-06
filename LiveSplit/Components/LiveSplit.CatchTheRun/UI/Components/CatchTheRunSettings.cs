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

        internal ClientCredentials Credentials { get; set; }
        internal List<Threshold> Thresholds { get; set; }
        internal string NotificationMessage { get; set; }
        internal bool ShowTriggerIndicator { get; set; }

        internal XmlHelper _XmlHelper { get; set; }
        internal ApiClient _ApiClient { get; set; }

        private BindingList<Threshold> ThresholdsDataSource { get; set; }

        private string CurrentlyEditingCellInitialValue { get; set; }
        private int BrowserEmulationInitialValue { get; set; }

        public CatchTheRunSettings(LiveSplitState state)
        {
            Run = state.Run;

            _XmlHelper = new XmlHelper(Run.FilePath.Substring(0, Run.FilePath.LastIndexOf('\\')));
            _ApiClient = new ApiClient();

            Credentials = _XmlHelper.ReadClientCredentials();
            Thresholds = _XmlHelper.ReadThresholds(Run.FilePath);
            ThresholdsDataSource = new BindingList<Threshold>(Thresholds);

            InitializeComponent();

            runGrid.DataSource = ThresholdsDataSource;
            runGrid.CellFormatting += runGrid_CellFormatting;
            runGrid.CellBeginEdit += runGrid_CellBeginEdit;
            runGrid.KeyDown += runGrid_KeyDown;
            runGrid.CellEndEdit += runGrid_CellEndEdit;
            verifyCredentialsButton.Enabled = !string.IsNullOrWhiteSpace(twitchUsernameTextBox.Text) && !string.IsNullOrWhiteSpace(clientKeyTextBox.Text);
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

        private void credentialsTextBox_TextChanged(object sender, EventArgs e)
        {
            verifyCredentialsButton.Enabled = !string.IsNullOrWhiteSpace(twitchUsernameTextBox.Text) && !string.IsNullOrWhiteSpace(clientKeyTextBox.Text);
        }
        private async void verifyCredentialsButton_Click(object sender, EventArgs e)
        {
            var verified = await _ApiClient.VerifyClientCredentials(twitchUsernameTextBox.Text, clientKeyTextBox.Text);

            if (verified)
                _XmlHelper.WriteClientCredentials(twitchUsernameTextBox.Text, clientKeyTextBox.Text);
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
            _XmlHelper.WriteThresholds(Run.FilePath, Util.ConvertDataRowsToDictionary(runGrid.Rows));
        }

        private async void registerCategoryButton_Click(object sender, EventArgs e)
        {
            var registrationSuccessful = await _ApiClient.RegisterFeedCategory(Credentials.ClientID, Run.GameName, Run.CategoryName);

            if (registrationSuccessful)
            { }
        }

        private void signIntoTwitchButton_Click(object sender, EventArgs e)
        {
            Util.ModifyBrowserEmulationKey(Util.BROWSER_EMULATION_PREFERRED_VALUE, out int initial);
            BrowserEmulationInitialValue = initial;

            var form = new TwitchOAuthForm();
            form.FormClosing += TwitchOAuthForm_FormClosing;
            form.ShowDialog();
        }

        private void TwitchOAuthForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Util.ModifyBrowserEmulationKey(BrowserEmulationInitialValue, out int _);
        }
    }
}
