﻿using Microsoft.Owin;
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

        public Router(Func<IOwinContext, Task> notFoundFunc)
        {
            _notFound = new Route("", notFoundFunc);
        }
        
        public void AddRoute(string path, Func<IOwinContext, Task> func)
        {
            _routes.Add(new Route(path, func));
        }

        public Task Run(IOwinContext context)
        {
            var route = _routes.SingleOrDefault(r => context.Request.Path.StartsWithSegments(new PathString(r.Prefix)));

            route = route ?? _notFound;

            return route.Handler(context);
        }

        private class Route
        {
            public string Prefix { get; set; }
            public Func<IOwinContext, Task> Handler { get; set; }

            public Route(string path, Func<IOwinContext, Task> func)
            {
                Prefix = path;
                Handler = func;
            }
        }
    }
}
