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
            this.twitchUsernameTextBox = new System.Windows.Forms.TextBox();
            this.twitchUsernameLabel = new System.Windows.Forms.Label();
            this.clientKeyLabel = new System.Windows.Forms.Label();
            this.clientKeyTextBox = new System.Windows.Forms.TextBox();
            this.verifyCredentialsButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.notificationMessageLabel = new System.Windows.Forms.Label();
            this.saveThresholdsButton = new System.Windows.Forms.Button();
            this.credentialsGroupBox = new System.Windows.Forms.GroupBox();
            this.signIntoTwitchButton = new System.Windows.Forms.Button();
            this.credentialsLabel = new System.Windows.Forms.Label();
            this.thresholdsGroupBox = new System.Windows.Forms.GroupBox();
            this.thresholdsLabel = new System.Windows.Forms.Label();
            this.miscSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.displayNotificationsTriggerCheckbox = new System.Windows.Forms.CheckBox();
            this.triggerColorLabel = new System.Windows.Forms.Label();
            this.btnTopColor = new System.Windows.Forms.Button();
            this.displayThresholdsCheckbox = new System.Windows.Forms.CheckBox();
            this.miscSettingsLabel = new System.Windows.Forms.Label();
            this.registerCategoryButton = new System.Windows.Forms.Button();
            this.splitNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thresholdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thresholdBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.runGrid)).BeginInit();
            this.credentialsGroupBox.SuspendLayout();
            this.thresholdsGroupBox.SuspendLayout();
            this.miscSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdBindingSource)).BeginInit();
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
            this.runGrid.Size = new System.Drawing.Size(654, 297);
            this.runGrid.TabIndex = 1;
            // 
            // twitchUsernameTextBox
            // 
            this.twitchUsernameTextBox.Location = new System.Drawing.Point(176, 35);
            this.twitchUsernameTextBox.Name = "twitchUsernameTextBox";
            this.twitchUsernameTextBox.Size = new System.Drawing.Size(490, 26);
            this.twitchUsernameTextBox.TabIndex = 2;
            this.twitchUsernameTextBox.TextChanged += new System.EventHandler(this.credentialsTextBox_TextChanged);
            // 
            // twitchUsernameLabel
            // 
            this.twitchUsernameLabel.AutoSize = true;
            this.twitchUsernameLabel.Location = new System.Drawing.Point(8, 38);
            this.twitchUsernameLabel.Name = "twitchUsernameLabel";
            this.twitchUsernameLabel.Size = new System.Drawing.Size(132, 20);
            this.twitchUsernameLabel.TabIndex = 3;
            this.twitchUsernameLabel.Text = "Twitch Username";
            // 
            // clientKeyLabel
            // 
            this.clientKeyLabel.AutoSize = true;
            this.clientKeyLabel.Location = new System.Drawing.Point(8, 79);
            this.clientKeyLabel.Name = "clientKeyLabel";
            this.clientKeyLabel.Size = new System.Drawing.Size(79, 20);
            this.clientKeyLabel.TabIndex = 4;
            this.clientKeyLabel.Text = "Client Key";
            // 
            // clientKeyTextBox
            // 
            this.clientKeyTextBox.Location = new System.Drawing.Point(176, 76);
            this.clientKeyTextBox.Name = "clientKeyTextBox";
            this.clientKeyTextBox.Size = new System.Drawing.Size(490, 26);
            this.clientKeyTextBox.TabIndex = 5;
            this.clientKeyTextBox.TextChanged += new System.EventHandler(this.credentialsTextBox_TextChanged);
            // 
            // verifyCredentialsButton
            // 
            this.verifyCredentialsButton.Location = new System.Drawing.Point(501, 119);
            this.verifyCredentialsButton.Name = "verifyCredentialsButton";
            this.verifyCredentialsButton.Size = new System.Drawing.Size(168, 32);
            this.verifyCredentialsButton.TabIndex = 6;
            this.verifyCredentialsButton.Text = "Verify Credentials";
            this.verifyCredentialsButton.UseVisualStyleBackColor = true;
            this.verifyCredentialsButton.Click += new System.EventHandler(this.verifyCredentialsButton_Click);
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
            this.saveThresholdsButton.Location = new System.Drawing.Point(500, 351);
            this.saveThresholdsButton.Name = "saveThresholdsButton";
            this.saveThresholdsButton.Size = new System.Drawing.Size(166, 32);
            this.saveThresholdsButton.TabIndex = 9;
            this.saveThresholdsButton.Text = "Save Thresholds";
            this.saveThresholdsButton.UseVisualStyleBackColor = true;
            this.saveThresholdsButton.Click += new System.EventHandler(this.saveThresholdsButton_Click);
            // 
            // credentialsGroupBox
            // 
            this.credentialsGroupBox.Controls.Add(this.signIntoTwitchButton);
            this.credentialsGroupBox.Controls.Add(this.credentialsLabel);
            this.credentialsGroupBox.Controls.Add(this.clientKeyLabel);
            this.credentialsGroupBox.Controls.Add(this.twitchUsernameTextBox);
            this.credentialsGroupBox.Controls.Add(this.clientKeyTextBox);
            this.credentialsGroupBox.Controls.Add(this.verifyCredentialsButton);
            this.credentialsGroupBox.Controls.Add(this.twitchUsernameLabel);
            this.credentialsGroupBox.Location = new System.Drawing.Point(13, 14);
            this.credentialsGroupBox.Name = "credentialsGroupBox";
            this.credentialsGroupBox.Size = new System.Drawing.Size(684, 170);
            this.credentialsGroupBox.TabIndex = 11;
            this.credentialsGroupBox.TabStop = false;
            // 
            // signIntoTwitchButton
            // 
            this.signIntoTwitchButton.Location = new System.Drawing.Point(327, 119);
            this.signIntoTwitchButton.Name = "signIntoTwitchButton";
            this.signIntoTwitchButton.Size = new System.Drawing.Size(168, 32);
            this.signIntoTwitchButton.TabIndex = 7;
            this.signIntoTwitchButton.Text = "Sign Into Twitch";
            this.signIntoTwitchButton.UseVisualStyleBackColor = true;
            this.signIntoTwitchButton.Click += new System.EventHandler(this.signIntoTwitchButton_Click);
            // 
            // credentialsLabel
            // 
            this.credentialsLabel.AutoSize = true;
            this.credentialsLabel.Location = new System.Drawing.Point(23, 0);
            this.credentialsLabel.Name = "credentialsLabel";
            this.credentialsLabel.Size = new System.Drawing.Size(250, 20);
            this.credentialsLabel.TabIndex = 0;
            this.credentialsLabel.Text = "Global Catch The Run Credentials";
            // 
            // thresholdsGroupBox
            // 
            this.thresholdsGroupBox.Controls.Add(this.saveThresholdsButton);
            this.thresholdsGroupBox.Controls.Add(this.thresholdsLabel);
            this.thresholdsGroupBox.Controls.Add(this.runGrid);
            this.thresholdsGroupBox.Location = new System.Drawing.Point(13, 200);
            this.thresholdsGroupBox.Name = "thresholdsGroupBox";
            this.thresholdsGroupBox.Size = new System.Drawing.Size(684, 405);
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
            this.miscSettingsGroupBox.Controls.Add(this.miscSettingsLabel);
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
            // miscSettingsLabel
            // 
            this.miscSettingsLabel.AutoSize = true;
            this.miscSettingsLabel.Location = new System.Drawing.Point(23, 0);
            this.miscSettingsLabel.Name = "miscSettingsLabel";
            this.miscSettingsLabel.Size = new System.Drawing.Size(108, 20);
            this.miscSettingsLabel.TabIndex = 9;
            this.miscSettingsLabel.Text = "Misc. Settings";
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
            // CatchTheRunSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.registerCategoryButton);
            this.Controls.Add(this.credentialsGroupBox);
            this.Controls.Add(this.thresholdsGroupBox);
            this.Controls.Add(this.miscSettingsGroupBox);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CatchTheRunSettings";
            this.Padding = new System.Windows.Forms.Padding(10, 11, 10, 11);
            this.Size = new System.Drawing.Size(710, 856);
            ((System.ComponentModel.ISupportInitialize)(this.runGrid)).EndInit();
            this.credentialsGroupBox.ResumeLayout(false);
            this.credentialsGroupBox.PerformLayout();
            this.thresholdsGroupBox.ResumeLayout(false);
            this.thresholdsGroupBox.PerformLayout();
            this.miscSettingsGroupBox.ResumeLayout(false);
            this.miscSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView runGrid;
        private System.Windows.Forms.TextBox twitchUsernameTextBox;
        private System.Windows.Forms.Label twitchUsernameLabel;
        private System.Windows.Forms.Label clientKeyLabel;
        private System.Windows.Forms.TextBox clientKeyTextBox;
        private System.Windows.Forms.Button verifyCredentialsButton;
        private System.Windows.Forms.BindingSource thresholdBindingSource;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label notificationMessageLabel;
        private System.Windows.Forms.Button saveThresholdsButton;
        private System.Windows.Forms.GroupBox credentialsGroupBox;
        private System.Windows.Forms.Label credentialsLabel;
        private System.Windows.Forms.GroupBox thresholdsGroupBox;
        private System.Windows.Forms.Label thresholdsLabel;
        private System.Windows.Forms.GroupBox miscSettingsGroupBox;
        private System.Windows.Forms.Label miscSettingsLabel;
        private System.Windows.Forms.CheckBox displayThresholdsCheckbox;
        private System.Windows.Forms.Button btnTopColor;
        private System.Windows.Forms.Label triggerColorLabel;
        private System.Windows.Forms.CheckBox displayNotificationsTriggerCheckbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn splitNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn splitTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn thresholdColumn;
        private System.Windows.Forms.Button registerCategoryButton;
        private System.Windows.Forms.Button signIntoTwitchButton;
    }
}
