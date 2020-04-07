using LiveSplit.Web;

namespace LiveSplit.CatchTheRun
{
    public static class Credentials
    {
        private const string Twitch = "CatchTheRun_TwitchUsername";
        private const string Guid = "CatchTheRun_AccountGuid";

        public static string TwitchUsername
        {
            get { return CredentialManager.ReadCredential(Twitch)?.Password; }
            set { CredentialManager.WriteCredential(Twitch, "", value); }
        }

        public static string AccountGuid
        {
            get { return CredentialManager.ReadCredential(Guid)?.Password; }
            set { CredentialManager.WriteCredential(Guid, "", value); }
        }

        public static void DeleteAllCredentials()
        {
            CredentialManager.DeleteCredential(Twitch);
            CredentialManager.DeleteCredential(Guid);
        }

        public static bool AnyCredentialsExist()
        {
            return CredentialManager.CredentialExists(Twitch)
                || CredentialManager.CredentialExists(Guid);
        }
    }
}
