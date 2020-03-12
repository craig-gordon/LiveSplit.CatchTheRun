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
            this.twitchUsernameTextBox = new System.Windows.Forms.TextBox();
            this.twitchUsernameLabel = new System.Windows.Forms.Label();
            this.clientKeyLabel = new System.Windows.Forms.Label();
            this.clientKeyTextBox = new System.Windows.Forms.TextBox();
            this.verifyCredentialsButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.notificationMessageLabel = new System.Windows.Forms.Label();
            this.saveThresholdsButton = new System.Windows.Forms.Button();
            this.saveCredentialsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.runGrid)).BeginInit();
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
            this.runGrid.Location = new System.Drawing.Point(20, 149);
            this.runGrid.Margin = new System.Windows.Forms.Padding(6, 0, 15, 15);
            this.runGrid.Name = "runGrid";
            this.runGrid.RowHeadersVisible = false;
            this.runGrid.RowHeadersWidth = 62;
            this.runGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.runGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.runGrid.Size = new System.Drawing.Size(629, 499);
            this.runGrid.TabIndex = 1;
            // 
            // splitNameColumn
            // 
            this.splitNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.splitNameColumn.DataPropertyName = "SplitName";
            this.splitNameColumn.HeaderText = "Split Name";
            this.splitNameColumn.MinimumWidth = 8;
            this.splitNameColumn.Name = "splitNameColumn";
            this.splitNameColumn.ReadOnly = true;
            this.splitNameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // splitTimeColumn
            // 
            this.splitTimeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.splitTimeColumn.DataPropertyName = "SplitTime";
            this.splitTimeColumn.HeaderText = "Split Time";
            this.splitTimeColumn.MinimumWidth = 8;
            this.splitTimeColumn.Name = "splitTimeColumn";
            this.splitTimeColumn.ReadOnly = true;
            this.splitTimeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // thresholdColumn
            // 
            this.thresholdColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.thresholdColumn.DataPropertyName = "ThresholdValue";
            this.thresholdColumn.HeaderText = "Threshold";
            this.thresholdColumn.MinimumWidth = 8;
            this.thresholdColumn.Name = "thresholdColumn";
            this.thresholdColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // thresholdBindingSource
            // 
            this.thresholdBindingSource.DataSource = typeof(LiveSplit.CatchTheRun.Threshold);
            // 
            // twitchUsernameTextBox
            // 
            this.twitchUsernameTextBox.Location = new System.Drawing.Point(183, 15);
            this.twitchUsernameTextBox.Name = "twitchUsernameTextBox";
            this.twitchUsernameTextBox.Size = new System.Drawing.Size(466, 26);
            this.twitchUsernameTextBox.TabIndex = 2;
            // 
            // twitchUsernameLabel
            // 
            this.twitchUsernameLabel.AutoSize = true;
            this.twitchUsernameLabel.Location = new System.Drawing.Point(16, 18);
            this.twitchUsernameLabel.Name = "twitchUsernameLabel";
            this.twitchUsernameLabel.Size = new System.Drawing.Size(132, 20);
            this.twitchUsernameLabel.TabIndex = 3;
            this.twitchUsernameLabel.Text = "Twitch Username";
            // 
            // clientKeyLabel
            // 
            this.clientKeyLabel.AutoSize = true;
            this.clientKeyLabel.Location = new System.Drawing.Point(16, 55);
            this.clientKeyLabel.Name = "clientKeyLabel";
            this.clientKeyLabel.Size = new System.Drawing.Size(79, 20);
            this.clientKeyLabel.TabIndex = 4;
            this.clientKeyLabel.Text = "Client Key";
            // 
            // clientKeyTextBox
            // 
            this.clientKeyTextBox.Location = new System.Drawing.Point(183, 52);
            this.clientKeyTextBox.Name = "clientKeyTextBox";
            this.clientKeyTextBox.Size = new System.Drawing.Size(466, 26);
            this.clientKeyTextBox.TabIndex = 5;
            // 
            // verifyCredentialsButton
            // 
            this.verifyCredentialsButton.Location = new System.Drawing.Point(348, 93);
            this.verifyCredentialsButton.Name = "verifyCredentialsButton";
            this.verifyCredentialsButton.Size = new System.Drawing.Size(143, 32);
            this.verifyCredentialsButton.TabIndex = 6;
            this.verifyCredentialsButton.Text = "Verify Credentials";
            this.verifyCredentialsButton.UseVisualStyleBackColor = true;
            this.verifyCredentialsButton.Click += new System.EventHandler(this.verifyCredentialsButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(182, 724);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(466, 98);
            this.textBox1.TabIndex = 7;
            // 
            // notificationMessageLabel
            // 
            this.notificationMessageLabel.AutoSize = true;
            this.notificationMessageLabel.Location = new System.Drawing.Point(15, 724);
            this.notificationMessageLabel.Name = "notificationMessageLabel";
            this.notificationMessageLabel.Size = new System.Drawing.Size(157, 20);
            this.notificationMessageLabel.TabIndex = 8;
            this.notificationMessageLabel.Text = "Notification Message";
            // 
            // saveThresholdsButton
            // 
            this.saveThresholdsButton.Location = new System.Drawing.Point(506, 666);
            this.saveThresholdsButton.Name = "saveThresholdsButton";
            this.saveThresholdsButton.Size = new System.Drawing.Size(142, 36);
            this.saveThresholdsButton.TabIndex = 9;
            this.saveThresholdsButton.Text = "Save Thresholds";
            this.saveThresholdsButton.UseVisualStyleBackColor = true;
            this.saveThresholdsButton.Click += new System.EventHandler(this.saveThresholdsButton_Click);
            // 
            // saveCredentialsButton
            // 
            this.saveCredentialsButton.Location = new System.Drawing.Point(506, 93);
            this.saveCredentialsButton.Name = "saveCredentialsButton";
            this.saveCredentialsButton.Size = new System.Drawing.Size(142, 32);
            this.saveCredentialsButton.TabIndex = 10;
            this.saveCredentialsButton.Text = "Save Credentials";
            this.saveCredentialsButton.UseVisualStyleBackColor = true;
            this.saveCredentialsButton.Click += new System.EventHandler(this.saveCredentialsButton_Click);
            // 
            // CatchTheRunSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.saveCredentialsButton);
            this.Controls.Add(this.saveThresholdsButton);
            this.Controls.Add(this.notificationMessageLabel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.verifyCredentialsButton);
            this.Controls.Add(this.clientKeyTextBox);
            this.Controls.Add(this.clientKeyLabel);
            this.Controls.Add(this.twitchUsernameLabel);
            this.Controls.Add(this.twitchUsernameTextBox);
            this.Controls.Add(this.runGrid);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CatchTheRunSettings";
            this.Padding = new System.Windows.Forms.Padding(10, 11, 10, 11);
            this.Size = new System.Drawing.Size(666, 861);
            ((System.ComponentModel.ISupportInitialize)(this.runGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView runGrid;
        private System.Windows.Forms.TextBox twitchUsernameTextBox;
        private System.Windows.Forms.Label twitchUsernameLabel;
        private System.Windows.Forms.Label clientKeyLabel;
        private System.Windows.Forms.TextBox clientKeyTextBox;
        private System.Windows.Forms.Button verifyCredentialsButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn splitNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn splitTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn thresholdColumn;
        private System.Windows.Forms.BindingSource thresholdBindingSource;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label notificationMessageLabel;
        private System.Windows.Forms.Button saveThresholdsButton;
        private System.Windows.Forms.Button saveCredentialsButton;
    }
}
