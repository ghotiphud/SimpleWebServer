using Microsoft.Owin;
using SimpleWebServer.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebServer.Hello
{
    public class HelloController : ControllerBase
    {
        public HelloController(IOwinContext context) : base(context) { }

        public Task Index(string name)
        {
            return _context.Response.WriteAsync(String.Format("Hello {0}!", name));
        }
    }
}
