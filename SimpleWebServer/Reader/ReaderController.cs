using Microsoft.Owin;
using SimpleWebServer.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebServer.Reader
{
    public class ReaderController : ControllerBase
    {
        private IReader _reader;

        public ReaderController(IOwinContext context, IReader reader) : base(context)
        {
            _reader = reader;
        }

        public Task Index()
        {
            return WriteTextAsync(String.Join(", ", _reader.Read()));
        }
    }
}
