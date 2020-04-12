﻿using System;
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
            bool success = await ApiClient.RegisterProducerCategory(Credentials.ProducerKey, Credentials.TwitchUsername, Run.GameName, Run.CategoryName);

            if (success)
            { }
        }

        private void logIntoTwitchButton_Click(object sender, EventArgs e)
        {
            Util.ModifyBrowserEmulationKey(Util.BROWSER_EMULATION_PREFERRED_VALUE, out int initial);
            BrowserEmulationInitialValue = initial;

            var form = new TwitchOAuthForm();
            form.FormClosing += TwitchOAuthForm_FormClosing;
            form.ShowDialog();
        }

        private void verifyChangedUsernameButton_Click(object sender, EventArgs e)
        {

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

        private void TwitchOAuthForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Util.ModifyBrowserEmulationKey(BrowserEmulationInitialValue, out int _);
            SetAuthenticationControlsState();
        }

        private void SetAuthenticationControlsState()
        {
            if (IsLoggedIn)
            {
                loggedInStatusLabel.Text = $"Logged In: {Credentials.TwitchUsername}";
                logIntoTwitchButton.Enabled = false;
                verifyChangedUsernameButton.Enabled = true;
                logOutButton.Enabled = true;
            }
            else
            {
                loggedInStatusLabel.Text = "Not Logged In";
                logIntoTwitchButton.Enabled = true;
                verifyChangedUsernameButton.Enabled = false;
                logOutButton.Enabled = false;
            }
        }
    }
}
