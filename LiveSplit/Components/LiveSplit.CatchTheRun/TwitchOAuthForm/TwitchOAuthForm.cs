using LiveSplit.Options;
using System;
using System.Windows.Forms;
using LiveSplit.Web;

namespace LiveSplit.CatchTheRun
{
    public partial class TwitchOAuthForm : Form
    {
        internal readonly Uri TwitchOAuthUrl = new Uri("https://id.twitch.tv/oauth2/authorize?client_id=cod7idgr6q9bucu2gic2594y80xsu7&redirect_uri=http://localhost&response_type=token+id_token&scope=openid");

        public string AccessToken { get; protected set; }

        public TwitchOAuthForm()
        {
            InitializeComponent();
        }

        void OAuthForm_Load(object sender, EventArgs e)
        {
            OAuthWebBrowser.Navigate(TwitchOAuthUrl);
        }

        private void OAuthWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                var url = OAuthWebBrowser.Url.Fragment.ToLowerInvariant();
                if (url.Contains("access_token"))
                {
                    var cutoff = url.Substring(url.IndexOf("access_token") + "access_token=".Length);
                    AccessToken = cutoff.Substring(0, cutoff.IndexOf("&"));

                    try
                    {
                        WebCredentials.TwitchAccessToken = AccessToken;
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex);
                    }

                    Action closeAction = () => Close();

                    if (InvokeRequired)
                        Invoke(closeAction);
                    else
                        closeAction();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }
    }
}
