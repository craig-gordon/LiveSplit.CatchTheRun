using LiveSplit.Web;

namespace LiveSplit.CatchTheRun
{
    public static class WebCredentials
    {
        private const string Twitch = "CatchTheRun_TwitchAccessToken";

        public static string TwitchAccessToken
        {
            get { return CredentialManager.ReadCredential(Twitch)?.Password; }
            set { CredentialManager.WriteCredential(Twitch, "", value); }
        }

        public static void DeleteAllCredentials()
        {
            CredentialManager.DeleteCredential(Twitch);
        }

        public static bool AnyCredentialsExist()
        {
            return CredentialManager.CredentialExists(Twitch);
        }
    }
}
