using Refit;

namespace Sample.Client
{
    public class UserCredentials
    {
        public UserCredentials(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        [AliasAs("username")]
        public string UserName { get; }

        [AliasAs("password")]
        public string Password { get; }

        [AliasAs("grant_type")]
        public string GrantType => "password";

        [AliasAs("scope")]
        public string Scope => "fooaccess";
    }
}