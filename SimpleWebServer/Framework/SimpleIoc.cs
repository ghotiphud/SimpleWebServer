using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebServer.Framework
{
    public class SimpleIoc
    {
        private SimpleIoc _parent;
        private Dictionary<Type, Func<SimpleIoc, object>> _typeResolvers = new Dictionary<Type, Func<SimpleIoc, object>>();

        public SimpleIoc(SimpleIoc parent = null)
        {
            _parent = parent;
        }

        public void Register<TTypeToResolve>(Func<SimpleIoc, TTypeToResolve> resolveFunc)
            where TTypeToResolve : class
        {
            _typeResolvers.Add(typeof(TTypeToResolve), resolveFunc);
        }

        public TTypeToResolve Resolve<TTypeToResolve>(SimpleIoc child = null)
            where TTypeToResolve : class
        {
            Func<SimpleIoc, object> resolveFunc;

            if (_typeResolvers.TryGetValue(typeof(TTypeToResolve), out resolveFunc))
            {
                return (TTypeToResolve)resolveFunc(child ?? this);
            }
            else
            {
                return _parent != null ?
                    _parent.Resolve<TTypeToResolve>(this) :
                    (TTypeToResolve)null;
            }
        }

        public SimpleIoc Scoped()
        {
            return new SimpleIoc(this);
        }
    }
}
