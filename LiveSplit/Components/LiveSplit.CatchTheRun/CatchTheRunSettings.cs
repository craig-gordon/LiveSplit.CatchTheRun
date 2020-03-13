﻿using System;
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
        private const int SPLIT_NAME_INDEX = 0;
        private const int SPLIT_TIME_INDEX = 1;
        private const int THRESHOLD_INDEX = 2;

        protected IRun Run { get; set; }

        internal ClientCredentials Credentials { get; set; }
        internal List<Threshold> Thresholds { get; set; }
        internal string NotificationMessage { get; set; }
        internal bool ShowTriggerIndicator { get; set; }

        internal XmlHelper _XmlHelper { get; set; }
        internal ApiClient _ApiClient { get; set; }

        protected BindingList<Threshold> ThresholdsDataSource { get; set; }

        public CatchTheRunSettings(LiveSplitState state)
        {
            Run = state.Run;
            Credentials = GetClientCredentials();
            _XmlHelper = new XmlHelper(Run.FilePath);
            Thresholds = _XmlHelper.ReadThresholds(Run.FilePath);
            ThresholdsDataSource = new BindingList<Threshold>(Thresholds);
            InitializeComponent();
            _ApiClient = new ApiClient();
            runGrid.DataSource = ThresholdsDataSource;
            runGrid.CellFormatting += runGrid_CellFormatting;
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

        internal ClientCredentials GetClientCredentials()
        {
            return _XmlHelper.ReadClientCredentials();
        }

        private void runGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < Run.Count && e.ColumnIndex == SPLIT_TIME_INDEX)
                e.Value = new ShortTimeFormatter().Format(Run[e.RowIndex].PersonalBestSplitTime[TimingMethod.RealTime]);
        }

        private async void verifyCredentialsButton_Click(object sender, EventArgs e)
        {
            await _ApiClient.VerifyClientCredentials(twitchUsernameTextBox.Text, clientKeyTextBox.Text);
        }

        private void saveThresholdsButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in runGrid.Rows)
            {
                var splitName = row.Cells[0].Value as string;
                var thresholdValue = row.Cells[2].Value as string;
                _XmlHelper.WriteThreshold(Run.FilePath, splitName, thresholdValue);
            }
        }

        private void saveCredentialsButton_Click(object sender, EventArgs e)
        {
            _XmlHelper.WriteClientCredentials(twitchUsernameTextBox.Text, clientKeyTextBox.Text);
        }
    }
}
