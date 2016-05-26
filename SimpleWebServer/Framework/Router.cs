using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebServer.Framework
{
    public class Router
    {
        private List<Route> _routes = new List<Route>();
        private Route _notFound;

        public Router(Func<SimpleIoc, Task> notFoundFunc)
        {
            _notFound = new Route("", notFoundFunc);
        }
        
        public void AddRoute(string path, Func<SimpleIoc, Task> func)
        {
            _routes.Add(new Route(path, func));
        }

        public Task Run(SimpleIoc ioc)
        {
            var path = ioc.Resolve<IOwinContext>().Request.Path;
            var route = _routes.SingleOrDefault(r => path.StartsWithSegments(new PathString(r.Prefix)));

            route = route ?? _notFound;

            return route.Handler(ioc);
        }

        private class Route
        {
            public string Prefix { get; set; }
            public Func<SimpleIoc, Task> Handler { get; set; }

            public Route(string path, Func<SimpleIoc, Task> func)
            {
                Prefix = path;
                Handler = func;
            }
        }
    }
}
