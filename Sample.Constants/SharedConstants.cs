namespace Sample.Constants
{
    public class SharedConstants
    {
        public const string ImplicitFlowClientId = "implicitclient";
        public const string ImplititFlowRedirectUri = "http://mdeptaoauthsampleapi.azurewebsites.net/";
        public const string MobileClientId = "mobileclient";
        public const string MobileRedirectUri = "http://mdepta.com/callback.html";
        public const string ResourceOwnerClientId = "resourceownerclient";
        public const string ClientCredentialsClientId = "clientcredentialsclient";
        public const string ClientSecret = "clientsecret";

        public const string FooScope = "fooaccess";

        public const string TokenAuthority = "https://mdeptaoauthidentityserver.azurewebsites.net/identity";
        public const string TokenEndpoint = "https://mdeptaoauthidentityserver.azurewebsites.net/identity/connect/token";
        public const string AuthorizationEndpoint = "https://mdeptaoauthidentityserver.azurewebsites.net/identity/connect/authorize";

        public const string ResourceServerUri = "https://mdeptaoauthsampleapi.azurewebsites.net/";
    }
}
