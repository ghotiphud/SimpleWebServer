using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebServer.Reader
{
    public class BeatlesReader : IReader
    {
        public List<string> Read()
        {
            return new List<string> { "John", "Paul", "George", "Ringo" };
        }
    }
}
