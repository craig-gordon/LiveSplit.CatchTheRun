using LiveSplit.Options;
using System;
using System.Windows.Forms;
using LiveSplit.Web;
using System.IdentityModel.Tokens.Jwt;
using System.Threading;
using System.Runtime.InteropServices;

namespace LiveSplit.CatchTheRun
{
    [ComVisible(true)]
    public partial class BrowserForm : Form
    {
        private const string ClientId = "cod7idgr6q9bucu2gic2594y80xsu7";
        private const string RedirectUri = "https://catch-the-run-website.cyghfer.now.sh/twitch";
        private const string ResponseType = "id_token";
        private const string Scope = "openid";

        private readonly Uri TwitchOAuthUrl = new Uri($"https://id.twitch.tv/oauth2/authorize?client_id={ClientId}&redirect_uri={RedirectUri}&response_type={ResponseType}&scope={Scope}");
        public readonly string ProducerKey = Guid.NewGuid().ToString("N").ToUpper();

        public BrowserForm()
        {
            InitializeComponent();
        }

        void BrowserForm_Load(object sender, EventArgs e)
        {
            browserEmbed.Navigate(TwitchOAuthUrl);
            browserEmbed.ObjectForScripting = this;
        }

        private void browserEmbed_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                var url = browserEmbed.Url.Fragment.ToLowerInvariant();
                if (url.Contains("id_token"))
                {
                    var idToken = url.Substring(url.IndexOf("id_token") + "id_token=".Length);

                    try
                    {
                        var jwt = new JwtSecurityTokenHandler().ReadJwtToken(idToken);

                        var responseReceived = false;
                        bool? success = null;

                        while (!responseReceived)
                        {
                            success = (bool?)browserEmbed.Document.InvokeScript("confirm");
                            if (success != null)
                            {
                                responseReceived = true;
                            }
                            Thread.Sleep(100);
                        }

                        if ((bool)success)
                        {
                            Credentials.TwitchUsername = (string)jwt.Payload["preferred_username"];
                            Credentials.ProducerKey = ProducerKey;
                        }
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
