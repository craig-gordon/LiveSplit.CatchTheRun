namespace LiveSplit.CatchTheRun
{
    partial class TwitchOAuthForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TwitchOAuthForm));
            this.OAuthWebBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // OAuthWebBrowser
            // 
            this.OAuthWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OAuthWebBrowser.Location = new System.Drawing.Point(0, 0);
            this.OAuthWebBrowser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OAuthWebBrowser.MinimumSize = new System.Drawing.Size(30, 31);
            this.OAuthWebBrowser.Name = "OAuthWebBrowser";
            this.OAuthWebBrowser.ScriptErrorsSuppressed = true;
            this.OAuthWebBrowser.Size = new System.Drawing.Size(1060, 1177);
            this.OAuthWebBrowser.TabIndex = 2;
            this.OAuthWebBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.OAuthWebBrowser_DocumentCompleted);
            // 
            // TwitchOAuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 1177);
            this.Controls.Add(this.OAuthWebBrowser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TwitchOAuthForm";
            this.Text = "Authenticate Twitch Account";
            this.Load += new System.EventHandler(this.OAuthForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser OAuthWebBrowser;
    }
}