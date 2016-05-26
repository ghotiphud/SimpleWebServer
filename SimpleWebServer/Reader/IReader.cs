using System.Collections.Generic;

namespace SimpleWebServer.Reader
{
    public interface IReader
    {
        List<string> Read();
    }
}