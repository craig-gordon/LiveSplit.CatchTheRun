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
            this.splitNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thresholdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thresholdBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.notificationMessageLabel = new System.Windows.Forms.Label();
            this.saveThresholdsButton = new System.Windows.Forms.Button();
            this.authenticateWithTwitchButton = new System.Windows.Forms.Button();
            this.thresholdsGroupBox = new System.Windows.Forms.GroupBox();
            this.thresholdsLabel = new System.Windows.Forms.Label();
            this.miscSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.displayNotificationsTriggerCheckbox = new System.Windows.Forms.CheckBox();
            this.triggerColorLabel = new System.Windows.Forms.Label();
            this.btnTopColor = new System.Windows.Forms.Button();
            this.displayThresholdsCheckbox = new System.Windows.Forms.CheckBox();
            this.settingsLabel = new System.Windows.Forms.Label();
            this.registerCategoryButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.runGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdBindingSource)).BeginInit();
            this.thresholdsGroupBox.SuspendLayout();
            this.miscSettingsGroupBox.SuspendLayout();
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
            this.splitNameColumn,
            this.splitTimeColumn,
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
            this.runGrid.Size = new System.Drawing.Size(654, 483);
            this.runGrid.TabIndex = 1;
            // 
            // splitNameColumn
            // 
            this.splitNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.splitNameColumn.DataPropertyName = "SplitName";
            this.splitNameColumn.HeaderText = "Split Name";
            this.splitNameColumn.MinimumWidth = 8;
            this.splitNameColumn.Name = "splitNameColumn";
            this.splitNameColumn.ReadOnly = true;
            this.splitNameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.splitNameColumn.Width = 208;
            // 
            // splitTimeColumn
            // 
            this.splitTimeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.splitTimeColumn.DataPropertyName = "SplitTime";
            this.splitTimeColumn.HeaderText = "Split Time";
            this.splitTimeColumn.MinimumWidth = 8;
            this.splitTimeColumn.Name = "splitTimeColumn";
            this.splitTimeColumn.ReadOnly = true;
            this.splitTimeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.splitTimeColumn.Width = 105;
            // 
            // thresholdColumn
            // 
            this.thresholdColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.thresholdColumn.DataPropertyName = "ThresholdValue";
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
            this.textBox1.Location = new System.Drawing.Point(176, 41);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(490, 61);
            this.textBox1.TabIndex = 7;
            // 
            // notificationMessageLabel
            // 
            this.notificationMessageLabel.AutoSize = true;
            this.notificationMessageLabel.Location = new System.Drawing.Point(8, 44);
            this.notificationMessageLabel.Name = "notificationMessageLabel";
            this.notificationMessageLabel.Size = new System.Drawing.Size(157, 20);
            this.notificationMessageLabel.TabIndex = 8;
            this.notificationMessageLabel.Text = "Notification Message";
            // 
            // saveThresholdsButton
            // 
            this.saveThresholdsButton.Location = new System.Drawing.Point(500, 537);
            this.saveThresholdsButton.Name = "saveThresholdsButton";
            this.saveThresholdsButton.Size = new System.Drawing.Size(166, 32);
            this.saveThresholdsButton.TabIndex = 9;
            this.saveThresholdsButton.Text = "Save Thresholds";
            this.saveThresholdsButton.UseVisualStyleBackColor = true;
            this.saveThresholdsButton.Click += new System.EventHandler(this.saveThresholdsButton_Click);
            // 
            // authenticateWithTwitchButton
            // 
            this.authenticateWithTwitchButton.Location = new System.Drawing.Point(13, 810);
            this.authenticateWithTwitchButton.Name = "authenticateWithTwitchButton";
            this.authenticateWithTwitchButton.Size = new System.Drawing.Size(195, 38);
            this.authenticateWithTwitchButton.TabIndex = 7;
            this.authenticateWithTwitchButton.Text = "Authenticate With Twitch";
            this.authenticateWithTwitchButton.UseVisualStyleBackColor = true;
            this.authenticateWithTwitchButton.Click += new System.EventHandler(this.authenticateWithTwitchButton_Click);
            // 
            // thresholdsGroupBox
            // 
            this.thresholdsGroupBox.Controls.Add(this.saveThresholdsButton);
            this.thresholdsGroupBox.Controls.Add(this.thresholdsLabel);
            this.thresholdsGroupBox.Controls.Add(this.runGrid);
            this.thresholdsGroupBox.Location = new System.Drawing.Point(13, 14);
            this.thresholdsGroupBox.Name = "thresholdsGroupBox";
            this.thresholdsGroupBox.Size = new System.Drawing.Size(684, 591);
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
            this.miscSettingsGroupBox.Controls.Add(this.displayNotificationsTriggerCheckbox);
            this.miscSettingsGroupBox.Controls.Add(this.triggerColorLabel);
            this.miscSettingsGroupBox.Controls.Add(this.btnTopColor);
            this.miscSettingsGroupBox.Controls.Add(this.displayThresholdsCheckbox);
            this.miscSettingsGroupBox.Controls.Add(this.settingsLabel);
            this.miscSettingsGroupBox.Controls.Add(this.textBox1);
            this.miscSettingsGroupBox.Controls.Add(this.notificationMessageLabel);
            this.miscSettingsGroupBox.Location = new System.Drawing.Point(13, 626);
            this.miscSettingsGroupBox.Name = "miscSettingsGroupBox";
            this.miscSettingsGroupBox.Size = new System.Drawing.Size(684, 162);
            this.miscSettingsGroupBox.TabIndex = 13;
            this.miscSettingsGroupBox.TabStop = false;
            // 
            // displayNotificationsTriggerCheckbox
            // 
            this.displayNotificationsTriggerCheckbox.AutoSize = true;
            this.displayNotificationsTriggerCheckbox.Location = new System.Drawing.Point(274, 121);
            this.displayNotificationsTriggerCheckbox.Name = "displayNotificationsTriggerCheckbox";
            this.displayNotificationsTriggerCheckbox.Size = new System.Drawing.Size(230, 24);
            this.displayNotificationsTriggerCheckbox.TabIndex = 17;
            this.displayNotificationsTriggerCheckbox.Text = "Display Notifications Trigger";
            this.displayNotificationsTriggerCheckbox.UseVisualStyleBackColor = true;
            // 
            // triggerColorLabel
            // 
            this.triggerColorLabel.AutoSize = true;
            this.triggerColorLabel.Location = new System.Drawing.Point(572, 122);
            this.triggerColorLabel.Name = "triggerColorLabel";
            this.triggerColorLabel.Size = new System.Drawing.Size(99, 20);
            this.triggerColorLabel.TabIndex = 16;
            this.triggerColorLabel.Text = "Trigger Color";
            // 
            // btnTopColor
            // 
            this.btnTopColor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTopColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTopColor.Location = new System.Drawing.Point(533, 117);
            this.btnTopColor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTopColor.Name = "btnTopColor";
            this.btnTopColor.Size = new System.Drawing.Size(32, 32);
            this.btnTopColor.TabIndex = 15;
            this.btnTopColor.UseVisualStyleBackColor = false;
            // 
            // displayThresholdsCheckbox
            // 
            this.displayThresholdsCheckbox.AutoSize = true;
            this.displayThresholdsCheckbox.Location = new System.Drawing.Point(12, 122);
            this.displayThresholdsCheckbox.Name = "displayThresholdsCheckbox";
            this.displayThresholdsCheckbox.Size = new System.Drawing.Size(168, 24);
            this.displayThresholdsCheckbox.TabIndex = 11;
            this.displayThresholdsCheckbox.Text = "Display Thresholds";
            this.displayThresholdsCheckbox.UseVisualStyleBackColor = true;
            // 
            // settingsLabel
            // 
            this.settingsLabel.AutoSize = true;
            this.settingsLabel.Location = new System.Drawing.Point(23, 0);
            this.settingsLabel.Name = "settingsLabel";
            this.settingsLabel.Size = new System.Drawing.Size(68, 20);
            this.settingsLabel.TabIndex = 9;
            this.settingsLabel.Text = "Settings";
            // 
            // registerCategoryButton
            // 
            this.registerCategoryButton.Location = new System.Drawing.Point(514, 810);
            this.registerCategoryButton.Name = "registerCategoryButton";
            this.registerCategoryButton.Size = new System.Drawing.Size(185, 38);
            this.registerCategoryButton.TabIndex = 14;
            this.registerCategoryButton.Text = "Register Category";
            this.registerCategoryButton.UseVisualStyleBackColor = true;
            this.registerCategoryButton.Click += new System.EventHandler(this.registerCategoryButton_Click);
            // 
            // CatchTheRunSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.authenticateWithTwitchButton);
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
        private System.Windows.Forms.Label settingsLabel;
        private System.Windows.Forms.CheckBox displayThresholdsCheckbox;
        private System.Windows.Forms.Button btnTopColor;
        private System.Windows.Forms.Label triggerColorLabel;
        private System.Windows.Forms.CheckBox displayNotificationsTriggerCheckbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn splitNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn splitTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn thresholdColumn;
        private System.Windows.Forms.Button registerCategoryButton;
        private System.Windows.Forms.Button authenticateWithTwitchButton;
    }
}
