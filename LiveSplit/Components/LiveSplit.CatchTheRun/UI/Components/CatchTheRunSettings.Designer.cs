namespace LiveSplit.UI.Components
{
    partial class CatchTheRunSettings
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.runGrid = new System.Windows.Forms.DataGridView();
            this.segmentNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pbSplitTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thresholdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thresholdBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.notificationMessageLabel = new System.Windows.Forms.Label();
            this.saveThresholdsButton = new System.Windows.Forms.Button();
            this.logIntoTwitchButton = new System.Windows.Forms.Button();
            this.thresholdsGroupBox = new System.Windows.Forms.GroupBox();
            this.thresholdsLabel = new System.Windows.Forms.Label();
            this.miscSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.notificationMessageTextLabel = new System.Windows.Forms.Label();
            this.registerCategoryButton = new System.Windows.Forms.Button();
            this.logOutButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.getUpdatedUsernameButton = new System.Windows.Forms.Button();
            this.loggedInStatusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.runGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdBindingSource)).BeginInit();
            this.thresholdsGroupBox.SuspendLayout();
            this.miscSettingsGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // runGrid
            // 
            this.runGrid.AllowDrop = true;
            this.runGrid.AllowUserToAddRows = false;
            this.runGrid.AllowUserToDeleteRows = false;
            this.runGrid.AllowUserToResizeColumns = false;
            this.runGrid.AllowUserToResizeRows = false;
            this.runGrid.AutoGenerateColumns = false;
            this.runGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.runGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.runGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.runGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.runGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.segmentNameColumn,
            this.pbSplitTimeColumn,
            this.thresholdColumn});
            this.runGrid.DataSource = this.thresholdBindingSource;
            this.runGrid.GridColor = System.Drawing.Color.Gainsboro;
            this.runGrid.Location = new System.Drawing.Point(12, 36);
            this.runGrid.Margin = new System.Windows.Forms.Padding(6, 0, 15, 15);
            this.runGrid.Name = "runGrid";
            this.runGrid.RowHeadersVisible = false;
            this.runGrid.RowHeadersWidth = 62;
            this.runGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.runGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.runGrid.Size = new System.Drawing.Size(660, 383);
            this.runGrid.TabIndex = 1;
            // 
            // segmentNameColumn
            // 
            this.segmentNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.segmentNameColumn.DataPropertyName = "SegmentName";
            this.segmentNameColumn.HeaderText = "Segment Name";
            this.segmentNameColumn.MinimumWidth = 8;
            this.segmentNameColumn.Name = "segmentNameColumn";
            this.segmentNameColumn.ReadOnly = true;
            this.segmentNameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.segmentNameColumn.Width = 208;
            // 
            // pbSplitTimeColumn
            // 
            this.pbSplitTimeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.pbSplitTimeColumn.DataPropertyName = "PersonalBestSplitTime";
            this.pbSplitTimeColumn.HeaderText = "PB Split Time";
            this.pbSplitTimeColumn.MinimumWidth = 8;
            this.pbSplitTimeColumn.Name = "pbSplitTimeColumn";
            this.pbSplitTimeColumn.ReadOnly = true;
            this.pbSplitTimeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.pbSplitTimeColumn.Width = 105;
            // 
            // thresholdColumn
            // 
            this.thresholdColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.thresholdColumn.DataPropertyName = "Value";
            this.thresholdColumn.HeaderText = "Threshold";
            this.thresholdColumn.MinimumWidth = 8;
            this.thresholdColumn.Name = "thresholdColumn";
            this.thresholdColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.thresholdColumn.Width = 105;
            // 
            // thresholdBindingSource
            // 
            this.thresholdBindingSource.DataSource = typeof(LiveSplit.CatchTheRun.Threshold);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(53, 41);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(618, 61);
            this.textBox1.TabIndex = 7;
            // 
            // notificationMessageLabel
            // 
            this.notificationMessageLabel.AutoSize = true;
            this.notificationMessageLabel.Location = new System.Drawing.Point(23, 0);
            this.notificationMessageLabel.Name = "notificationMessageLabel";
            this.notificationMessageLabel.Size = new System.Drawing.Size(157, 20);
            this.notificationMessageLabel.TabIndex = 8;
            this.notificationMessageLabel.Text = "Notification Message";
            // 
            // saveThresholdsButton
            // 
            this.saveThresholdsButton.Location = new System.Drawing.Point(456, 437);
            this.saveThresholdsButton.Name = "saveThresholdsButton";
            this.saveThresholdsButton.Size = new System.Drawing.Size(215, 38);
            this.saveThresholdsButton.TabIndex = 9;
            this.saveThresholdsButton.Text = "Save Thresholds";
            this.saveThresholdsButton.UseVisualStyleBackColor = true;
            this.saveThresholdsButton.Click += new System.EventHandler(this.saveThresholdsButton_Click);
            // 
            // logIntoTwitchButton
            // 
            this.logIntoTwitchButton.Location = new System.Drawing.Point(11, 25);
            this.logIntoTwitchButton.Name = "logIntoTwitchButton";
            this.logIntoTwitchButton.Size = new System.Drawing.Size(216, 38);
            this.logIntoTwitchButton.TabIndex = 7;
            this.logIntoTwitchButton.Text = "Log Into Twitch";
            this.logIntoTwitchButton.UseVisualStyleBackColor = true;
            this.logIntoTwitchButton.Click += new System.EventHandler(this.logIntoTwitchButton_Click);
            // 
            // thresholdsGroupBox
            // 
            this.thresholdsGroupBox.Controls.Add(this.saveThresholdsButton);
            this.thresholdsGroupBox.Controls.Add(this.thresholdsLabel);
            this.thresholdsGroupBox.Controls.Add(this.runGrid);
            this.thresholdsGroupBox.Location = new System.Drawing.Point(13, 112);
            this.thresholdsGroupBox.Name = "thresholdsGroupBox";
            this.thresholdsGroupBox.Size = new System.Drawing.Size(684, 493);
            this.thresholdsGroupBox.TabIndex = 12;
            this.thresholdsGroupBox.TabStop = false;
            // 
            // thresholdsLabel
            // 
            this.thresholdsLabel.AutoSize = true;
            this.thresholdsLabel.Location = new System.Drawing.Point(23, 0);
            this.thresholdsLabel.Name = "thresholdsLabel";
            this.thresholdsLabel.Size = new System.Drawing.Size(87, 20);
            this.thresholdsLabel.TabIndex = 2;
            this.thresholdsLabel.Text = "Thresholds";
            // 
            // miscSettingsGroupBox
            // 
            this.miscSettingsGroupBox.Controls.Add(this.notificationMessageTextLabel);
            this.miscSettingsGroupBox.Controls.Add(this.textBox1);
            this.miscSettingsGroupBox.Controls.Add(this.notificationMessageLabel);
            this.miscSettingsGroupBox.Location = new System.Drawing.Point(13, 626);
            this.miscSettingsGroupBox.Name = "miscSettingsGroupBox";
            this.miscSettingsGroupBox.Size = new System.Drawing.Size(684, 162);
            this.miscSettingsGroupBox.TabIndex = 13;
            this.miscSettingsGroupBox.TabStop = false;
            // 
            // notificationMessageTextLabel
            // 
            this.notificationMessageTextLabel.AutoSize = true;
            this.notificationMessageTextLabel.Location = new System.Drawing.Point(8, 44);
            this.notificationMessageTextLabel.Name = "notificationMessageTextLabel";
            this.notificationMessageTextLabel.Size = new System.Drawing.Size(39, 20);
            this.notificationMessageTextLabel.TabIndex = 9;
            this.notificationMessageTextLabel.Text = "Text";
            // 
            // registerCategoryButton
            // 
            this.registerCategoryButton.Location = new System.Drawing.Point(14, 810);
            this.registerCategoryButton.Name = "registerCategoryButton";
            this.registerCategoryButton.Size = new System.Drawing.Size(683, 38);
            this.registerCategoryButton.TabIndex = 14;
            this.registerCategoryButton.Text = "Register Category";
            this.registerCategoryButton.UseVisualStyleBackColor = true;
            this.registerCategoryButton.Click += new System.EventHandler(this.registerCategoryButton_Click);
            // 
            // logOutButton
            // 
            this.logOutButton.Enabled = false;
            this.logOutButton.Location = new System.Drawing.Point(233, 25);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(216, 38);
            this.logOutButton.TabIndex = 16;
            this.logOutButton.Text = "Log Out";
            this.logOutButton.UseVisualStyleBackColor = true;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.getUpdatedUsernameButton);
            this.groupBox1.Controls.Add(this.loggedInStatusLabel);
            this.groupBox1.Controls.Add(this.logIntoTwitchButton);
            this.groupBox1.Controls.Add(this.logOutButton);
            this.groupBox1.Location = new System.Drawing.Point(14, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(683, 77);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // getUpdatedUsernameButton
            // 
            this.getUpdatedUsernameButton.Enabled = false;
            this.getUpdatedUsernameButton.Location = new System.Drawing.Point(455, 25);
            this.getUpdatedUsernameButton.Name = "getUpdatedUsernameButton";
            this.getUpdatedUsernameButton.Size = new System.Drawing.Size(216, 38);
            this.getUpdatedUsernameButton.TabIndex = 17;
            this.getUpdatedUsernameButton.Text = "Get Updated Username";
            this.getUpdatedUsernameButton.UseVisualStyleBackColor = true;
            this.getUpdatedUsernameButton.Click += new System.EventHandler(this.getUpdatedUsernameButton_Click);
            // 
            // loggedInStatusLabel
            // 
            this.loggedInStatusLabel.AutoSize = true;
            this.loggedInStatusLabel.Location = new System.Drawing.Point(22, -3);
            this.loggedInStatusLabel.Name = "loggedInStatusLabel";
            this.loggedInStatusLabel.Size = new System.Drawing.Size(110, 20);
            this.loggedInStatusLabel.TabIndex = 10;
            this.loggedInStatusLabel.Text = "Not Logged In";
            // 
            // CatchTheRunSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.registerCategoryButton);
            this.Controls.Add(this.thresholdsGroupBox);
            this.Controls.Add(this.miscSettingsGroupBox);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CatchTheRunSettings";
            this.Padding = new System.Windows.Forms.Padding(10, 11, 10, 11);
            this.Size = new System.Drawing.Size(710, 856);
            ((System.ComponentModel.ISupportInitialize)(this.runGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdBindingSource)).EndInit();
            this.thresholdsGroupBox.ResumeLayout(false);
            this.thresholdsGroupBox.PerformLayout();
            this.miscSettingsGroupBox.ResumeLayout(false);
            this.miscSettingsGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView runGrid;
        private System.Windows.Forms.BindingSource thresholdBindingSource;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label notificationMessageLabel;
        private System.Windows.Forms.Button saveThresholdsButton;
        private System.Windows.Forms.GroupBox thresholdsGroupBox;
        private System.Windows.Forms.Label thresholdsLabel;
        private System.Windows.Forms.GroupBox miscSettingsGroupBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn segmentNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pbSplitTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn thresholdColumn;
        private System.Windows.Forms.Button registerCategoryButton;
        private System.Windows.Forms.Button logIntoTwitchButton;
        private System.Windows.Forms.Button logOutButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button getUpdatedUsernameButton;
        private System.Windows.Forms.Label loggedInStatusLabel;
        private System.Windows.Forms.Label notificationMessageTextLabel;
    }
}
