using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;
using Owin;

namespace Sample.IdentityServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/identity", idServerApp =>
            {
                var idServiceFactory = new IdentityServerServiceFactory()
                    .UseInMemoryUsers(Users.Get())
                    .UseInMemoryClients(Clients.Get())
                    .UseInMemoryScopes(Scopes.Get());

               // idServiceFactory.ClientStore = new Registration<IClientStore>(new MyClientStore(), "CustomClientStore");
                
                var options = new IdentityServerOptions
                {
                    Factory = idServiceFactory,
                    SiteName = "Michal's Identity Server",
                    IssuerUri = "https://michal/identity",
                    SigningCertificate = new X509Certificate2(
                        $"{AppDomain.CurrentDomain.BaseDirectory}\\Certificates\\idsrv3test.pfx", "idsrv3test")
                    //PublicOrigin = ""
                };

                idServerApp.UseIdentityServer(options);
            });
        }
    }

    public class MyClientStore : IClientStore
    {
        private IEnumerable<Client> _clients = Clients.Get();

        public Task<Client> FindClientByIdAsync(string clientId)
        {
            var matching = _clients.SingleOrDefault(c => c.ClientId == clientId);

            return Task.FromResult(matching);
        }
    }
}