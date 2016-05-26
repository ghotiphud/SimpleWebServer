using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebServer.Framework
{
    public abstract class ControllerBase
    {
        protected IOwinContext _context;

        public ControllerBase(IOwinContext context)
        {
            _context = context;
        }
    }
}
