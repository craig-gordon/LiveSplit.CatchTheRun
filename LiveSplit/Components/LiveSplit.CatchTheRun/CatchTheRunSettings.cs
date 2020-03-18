using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Xml;
using System.ComponentModel;
using LiveSplit.Model;
using System.Drawing;
using LiveSplit.TimeFormatters;
using System.Collections.Generic;
using System.IO;
using LiveSplit.Model.RunFactories;
using LiveSplit.Model.Comparisons;
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
            runGrid.CellEndEdit += runGrid_CellEndEdit;
            verifyCredentialsButton.Enabled = !string.IsNullOrWhiteSpace(twitchUsernameTextBox.Text) && !string.IsNullOrWhiteSpace(clientKeyTextBox.Text);
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
            await _ApiClient.VerifyClientCredentials(twitchUsernameTextBox.Text, clientKeyTextBox.Text);
        }

        private void saveCredentialsButton_Click(object sender, EventArgs e)
        {
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

        private void runGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != Util.THRESHOLD_INDEX)
                return;

            var cell = runGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var value = (string)cell.Value;

            if (!Util.IsThresholdInputValid(value))
                cell.Value = CurrentlyEditingCellInitialValue;
        }

        private void saveThresholdsButton_Click(object sender, EventArgs e)
        {
            _XmlHelper.WriteThresholds(Run.FilePath, Util.ConvertDataRowsToDictionary(runGrid.Rows));
        }
    }
}
