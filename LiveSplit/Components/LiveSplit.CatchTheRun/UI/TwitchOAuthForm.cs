using LiveSplit.Options;
using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Web.Script.Serialization;

namespace LiveSplit.CatchTheRun
{
    [ComVisible(true)]
    public partial class TwitchOAuthForm : Form
    {
        internal const string TokenType = "id_token";
        internal const string ClientId = "cod7idgr6q9bucu2gic2594y80xsu7";
        internal const string RedirectUrl = "https://catch-the-run-website.cyghfer.now.sh/twitch";
        internal const string Scope = "openid";

        public TwitchOAuthForm()
        {
            InitializeComponent();
            OAuthWebBrowser.ObjectForScripting = this;
        }

        void OAuthForm_Load(object sender, EventArgs e)
        {
            try
            {
                OAuthWebBrowser.Navigate(new Uri(
                    string.Format(
                        "https://id.twitch.tv/oauth2/authorize?response_type={0}&client_id={1}&redirect_uri={2}&scope={3}",
                        TokenType,
                        ClientId,
                        RedirectUrl,
                        Scope
                    ),
                    UriKind.Absolute
                ));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void OAuthWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var url = e.Url.AbsoluteUri;
            if (url.Contains($"{TokenType}="))
                new Thread(Loop).Start();
        }

        private void Loop()
        {
            Thread.Sleep(50);
            Func<bool> processAction = () => ProcessResponse();
            var received = (bool)Invoke(processAction);
            if (!received)
                new Thread(Loop).Start();
        }

        private bool ProcessResponse()
        {
            try
            {
                object rawResponse = OAuthWebBrowser.Document.InvokeScript("getResponse");

                if (rawResponse is System.DBNull)
                    return false;

                TwitchLoginResponse response = (TwitchLoginResponse)new JavaScriptSerializer().Deserialize((string)rawResponse, typeof(TwitchLoginResponse));

                if (response?.TwitchUsername != null)
                {
                    try
                    {
                        Credentials.TwitchUsername = response.TwitchUsername;
                        Credentials.TwitchUserId = response.TwitchUserId;
                        Credentials.ProducerKey = response.ProducerKey;
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex);
                    }
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

            return true;
        }
    }
}
