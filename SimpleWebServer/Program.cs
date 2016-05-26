using SimpleWebServer.Hello;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://localhost:8888";
            using (WebApp.Start(url, Configuration))
            {
                Console.WriteLine("Hosting on {0}", url);
                Console.WriteLine("Press [enter] to Quit");
                Console.ReadLine();
            }
        }

        
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public static void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.Run(context => {
                var path = context.Request.Path;

                // default ContentType
                context.Response.ContentType = "text/HTML";
                context.Response.StatusCode = 200;

                // /hello/{name}
                if (path.StartsWithSegments(new PathString("/hello")))
                {
                    var name = path.Value.Substring(7);

                    return new HelloController().Index(context, name);
                }

                // /goodbye
                if(path.Value == "/goodbye")
                {
                    return context.Response.WriteAsync("Goodbye.");
                }

                context.Response.StatusCode = 404;
                return context.Response.WriteAsync("404");
            });
        }
    }
}
