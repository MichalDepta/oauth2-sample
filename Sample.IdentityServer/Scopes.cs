using System.Collections.Generic;
using System.Collections.ObjectModel;
using IdentityServer3.Core.Models;
using Sample.Constants;

namespace Sample.IdentityServer
{
    public static class Scopes
    {
        public static IEnumerable<Scope> Get() => new ReadOnlyCollection<Scope>(new List<Scope>
        {
            new Scope
            {
                Name = SharedConstants.FooScope,
                DisplayName = "Access to the Foo API",
                Description = "Allow the application to execute foo requests",
                Type = ScopeType.Resource
            }
        });
    }
}