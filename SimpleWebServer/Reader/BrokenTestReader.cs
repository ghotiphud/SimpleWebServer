using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebServer.Reader
{
    public class BrokenTestReader : IReader
    {
        public List<string> Read()
        {
            throw new NotImplementedException();
        }
    }
}
