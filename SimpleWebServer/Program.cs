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
            var iocContainer = new SimpleIoc();

            iocContainer.Register<HelloController, HelloController>(
                innerIoc => new HelloController(innerIoc.Resolve<IOwinContext>()));

            iocContainer.Register<GoodbyeController, GoodbyeController>(
                innerIoc => new GoodbyeController(innerIoc.Resolve<IOwinContext>()));
            


            var router = new Router((ioc) => {
                var context = ioc.Resolve<IOwinContext>();
                context.Response.StatusCode = 404;
                return context.Response.WriteAsync("404");
            });

            router.AddRoute("/hello", (ioc) =>
            {
                var context = ioc.Resolve<IOwinContext>();
                var name = context.Request.Path.Value.Substring(7);

                return ioc.Resolve<HelloController>().Index(name);
            });

            router.AddRoute("/goodbye", (ioc) =>
            {
                return ioc.Resolve<GoodbyeController>().Index();
            });


            appBuilder.Run(context =>
            {
                var scoped_ioc = iocContainer.Scoped();
                scoped_ioc.Register<IOwinContext, IOwinContext>(_ => context);

                // default ContentType
                context.Response.ContentType = "text/HTML";
                context.Response.StatusCode = 200;

                return router.Run(scoped_ioc);
            });
        }
    }
}
