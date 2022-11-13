using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Tests
{
    public static class AutofacDependencyResolverExtensions
    {

        public static T GetService<T>(this IContainer dependencyResolver) where T : class
        {
            return dependencyResolver.Resolve<T>();
        }
        public static T GetService<T>(this ILifetimeScope scope) where T : class
        {
            return scope.Resolve<T>();
        }
    }
}
