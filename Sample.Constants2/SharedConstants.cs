namespace Sample.Constants
{
    public class SharedConstants
    {
        public const string ImplicitFlowClientId = "implicitclient";
        public const string ImplititFlowRedirectUri = "http://mdeptaoauthsampleapi.azurewebsites.net/";
        public const string MobileClientId = "mobileclient";
        public const string MobileRedirectUri = "mdepta://callback.html";
        public const string ResourceOwnerClientId = "resourceownerclient";
        public const string ClientCredentialsClientId = "clientcredentialsclient";
        public const string ClientSecret = "clientsecret";

        public const string FooScope = "fooaccess";

        public const string TokenEndpoint = "https://mdeptaoauthidentityserver.azurewebsites.net/identity/connect/token";
    }
}