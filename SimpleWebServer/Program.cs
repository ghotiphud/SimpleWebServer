using SimpleWebServer.Hello;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWebServer.Goodbye;
using SimpleWebServer.Framework;

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
            var router = new Router((context) => {
                context.Response.StatusCode = 404;
                return context.Response.WriteAsync("404");
            });

            router.AddRoute("/hello", (context) =>
            {
                var name = context.Request.Path.Value.Substring(7);

                return new HelloController(context).Index(name);
            });

            router.AddRoute("/goodbye", (context) =>
            {
                return new GoodbyeController(context).Index();
            });

            appBuilder.Run(context =>
            {
                // default ContentType
                context.Response.ContentType = "text/HTML";
                context.Response.StatusCode = 200;

                return router.Run(context);
            });
        }
    }
}
