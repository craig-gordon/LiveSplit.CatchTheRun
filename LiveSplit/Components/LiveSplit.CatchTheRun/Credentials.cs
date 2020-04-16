using LiveSplit.Web;

namespace LiveSplit.CatchTheRun
{
    public static class Credentials
    {
        private const string Username = "CatchTheRun_TwitchUsername";
        private const string UserId = "CatchTheRun_TwitchUserId";
        private const string Key = "CatchTheRun_ProducerKey";

        public static string TwitchUsername
        {
            get { return CredentialManager.ReadCredential(Username)?.Password; }
            set { CredentialManager.WriteCredential(Username, "", value); }
        }

        public static string TwitchUserId
        {
            get { return CredentialManager.ReadCredential(UserId)?.Password; }
            set { CredentialManager.WriteCredential(UserId, "", value); }
        }

        public static string ProducerKey
        {
            get { return CredentialManager.ReadCredential(Key)?.Password; }
            set { CredentialManager.WriteCredential(Key, "", value); }
        }

        public static void DeleteAllCredentials()
        {
            CredentialManager.DeleteCredential(Username);
            CredentialManager.DeleteCredential(Key);
            CredentialManager.DeleteCredential(UserId);
        }

        public static bool AnyCredentialsExist()
        {
            return CredentialManager.CredentialExists(Username)
                || CredentialManager.CredentialExists(UserId)
                || CredentialManager.CredentialExists(Key);
        }
    }
}
