using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sample.API.Controllers
{
    [Authorize]
    public class FooController : ApiController
    {
        // GET: api/Foo
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Foo/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Foo
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Foo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Foo/5
        public void Delete(int id)
        {
        }
    }
}
