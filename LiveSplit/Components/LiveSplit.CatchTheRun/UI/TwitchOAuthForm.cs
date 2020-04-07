using LiveSplit.Options;
using System;
using System.Windows.Forms;
using LiveSplit.Web;
using System.IdentityModel.Tokens.Jwt;

namespace LiveSplit.CatchTheRun
{
    public partial class TwitchOAuthForm : Form
    {
        internal readonly Uri TwitchOAuthUrl = new Uri("https://id.twitch.tv/oauth2/authorize?client_id=cod7idgr6q9bucu2gic2594y80xsu7&redirect_uri=http://localhost&response_type=id_token&scope=openid");

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
                if (url.Contains("id_token"))
                {
                    var cutoff = url.Substring(url.IndexOf("id_token") + "id_token=".Length);
                    var idToken = cutoff.Substring(0, cutoff.IndexOf("&"));

                    try
                    {
                        var jwt = new JwtSecurityTokenHandler().ReadJwtToken(idToken);
                        Credentials.TwitchUsername = (string)jwt.Payload["preferred_username"];
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
