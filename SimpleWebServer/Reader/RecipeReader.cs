using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebServer.Reader
{
    public class RecipeReader : IReader
    {
        public List<string> Read()
        {
            return new List<string> { "Sugar", "Spice", "Everything Nice", "Slugs", "Snails", "Puppy dog tails" };
        }
    }
}
