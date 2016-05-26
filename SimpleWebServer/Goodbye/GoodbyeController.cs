using Microsoft.Owin;
using SimpleWebServer.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebServer.Goodbye
{
    public class GoodbyeController : ControllerBase
    {
        public GoodbyeController(IOwinContext context) : base(context) { }

        public Task Index()
        {
            return _context.Response.WriteAsync("Goodbye.");
        }
    }
}
