using LiveSplit.Options;
using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace LiveSplit.CatchTheRun
{
    [ComVisible(true)]
    public partial class TwitchOAuthForm : Form
    {
        internal const string TokenType = "id_token";
        internal const string ClientId = "cod7idgr6q9bucu2gic2594y80xsu7";
        internal const string RedirectUrl = "https://catch-the-run-website.cyghfer.now.sh/twitch";
        internal const string Scope = "openid";

        public readonly string ProducerKey = Guid.NewGuid().ToString("N").ToUpperInvariant();
        public string IdToken { get; protected set; }

        public TwitchOAuthForm()
        {
            var t = Credentials.TwitchUsername;
            var p = Credentials.ProducerKey;
            InitializeComponent();
            OAuthWebBrowser.ObjectForScripting = this;
        }

        void OAuthForm_Load(object sender, EventArgs e)
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

        private void OAuthWebBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            var url = e.Url.AbsoluteUri;
            if (url.Contains($"{TokenType}="))
                IdToken = url.Substring(url.IndexOf(TokenType) + $"{TokenType}=".Length);
        }

        private void OAuthWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                var url = e.Url.AbsoluteUri;
                if (url.Contains($"{TokenType}="))
                    new Thread(Test).Start();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void Test()
        {
            Thread.Sleep(5000);
            Func<bool> processAction = () => ProcessResponse();
            if (!(bool)Invoke(processAction))
                new Thread(Test).Start();
        }

        private bool ProcessResponse()
        {
            var username = OAuthWebBrowser.Document.InvokeScript("get");

            if (username == null)
                return false;

            if ((string)username != "")
            {
                try
                {
                    Credentials.TwitchUsername = (string)username;
                    Credentials.ProducerKey = ProducerKey;
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                }
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
