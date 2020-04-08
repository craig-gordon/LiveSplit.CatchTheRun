namespace LiveSplit.CatchTheRun
{
    partial class BrowserForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowserForm));
            this.browserEmbed = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // browserEmbed
            // 
            this.browserEmbed.AllowWebBrowserDrop = false;
            this.browserEmbed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserEmbed.Location = new System.Drawing.Point(0, 0);
            this.browserEmbed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.browserEmbed.MinimumSize = new System.Drawing.Size(30, 31);
            this.browserEmbed.Name = "browserEmbed";
            this.browserEmbed.Size = new System.Drawing.Size(1020, 1200);
            this.browserEmbed.TabIndex = 2;
            this.browserEmbed.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.browserEmbed_DocumentCompleted);
            // 
            // BrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 1200);
            this.Controls.Add(this.browserEmbed);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BrowserForm";
            this.Text = "Verify Twitch Account";
            this.Load += new System.EventHandler(this.BrowserForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser browserEmbed;
    }
}