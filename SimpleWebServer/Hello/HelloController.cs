using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebServer.Hello
{
    public class HelloController
    {
        public Task Index(IOwinContext context, string name)
        {
            return context.Response.WriteAsync(String.Format("Hello {0}!", name));
        }
    }
}
