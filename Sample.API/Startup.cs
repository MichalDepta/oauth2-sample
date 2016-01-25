using IdentityServer3.AccessTokenValidation;
using Owin;
using Sample.Constants;

namespace Sample.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseIdentityServerBearerTokenAuthentication(
                new IdentityServerBearerTokenAuthenticationOptions
                {
                    Authority = SharedConstants.TokenAuthority,
                    RequiredScopes = new[] { SharedConstants.FooScope }
                });
        }
    }
}