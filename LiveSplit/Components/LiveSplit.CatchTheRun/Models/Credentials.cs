using LiveSplit.Web;

namespace LiveSplit.CatchTheRun
{
    public static class Credentials
    {
        private const string Twitch = "CatchTheRun_TwitchUsername";
        private const string Key = "CatchTheRun_ProducerKey";

        public static string TwitchUsername
        {
            get { return CredentialManager.ReadCredential(Twitch)?.Password; }
            set { CredentialManager.WriteCredential(Twitch, "", value); }
        }

        public static string ProducerKey
        {
            get { return CredentialManager.ReadCredential(Key)?.Password; }
            set { CredentialManager.WriteCredential(Key, "", value); }
        }

        public static void DeleteAllCredentials()
        {
            CredentialManager.DeleteCredential(Twitch);
            CredentialManager.DeleteCredential(Key);
        }

        public static bool AnyCredentialsExist()
        {
            return CredentialManager.CredentialExists(Twitch)
                || CredentialManager.CredentialExists(Key);
        }
    }
}
