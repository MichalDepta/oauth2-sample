using System.Collections.Generic;
using System.Collections.ObjectModel;
using IdentityServer3.Core.Models;
using Sample.Constants;

namespace Sample.IdentityServer
{
    public static class Clients
    {
        public static IEnumerable<Client> Get() => new ReadOnlyCollection<Client>(new List<Client>
        {
            new Client
            {
                Flow = Flows.ClientCredentials,
                ClientId = SharedConstants.ClientCredentialsClientId,
                ClientName = "Sample API Client (Client Credentials)",
                ClientSecrets = new List<Secret>
                {
                    new Secret(SharedConstants.ClientSecret.Sha256())
                },
                AllowedScopes = new List<string> {SharedConstants.FooScope}
            },
            new Client
            {
                Flow = Flows.ResourceOwner,
                ClientId = SharedConstants.ResourceOwnerClientId,
                ClientName = "Sample API Client (Resource Owner Password Credentials)",
                AllowedScopes = new List<string> {SharedConstants.FooScope},
                ClientSecrets = new List<Secret>
                {
                    new Secret(SharedConstants.ClientSecret.Sha256())
                },
            },
            new Client
            {
                Flow = Flows.Implicit,
                ClientId = SharedConstants.ImplicitFlowClientId,
                ClientName = "Sample API Client (Implicit Flow)",
                AllowedScopes = new List<string> {SharedConstants.FooScope},
                RedirectUris = new List<string> {SharedConstants.ImplititFlowRedirectUri}
            },
            new Client
            {
                Flow = Flows.Implicit,
                ClientId = SharedConstants.MobileClientId,
                ClientName = "Sample API Mobile Client (Implicit Flow)",
                AllowedScopes = new List<string> {SharedConstants.FooScope},
                RedirectUris = new List<string> {SharedConstants.MobileRedirectUri}
            }
        });
    }
}