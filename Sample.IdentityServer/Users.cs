using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using IdentityServer3.Core.Services.InMemory;

namespace Sample.IdentityServer
{
    public static class Users
    {
        public static List<InMemoryUser> Get() => new List<InMemoryUser>
        {
            new InMemoryUser {Username = "Michal", Password = "password", Subject = Guid.NewGuid().ToString()}
        };
    }
}