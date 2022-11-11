using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Tests
{
    static class DependencyResolver
    {
        private static IContainer mCurrent;
        public static IContainer Current
        {
            get
            {
                if (mCurrent == null)
                {
                    var builder = new ContainerBuilder();
                    builder.RegisterModule(new Configuration());
                    mCurrent = builder.Build();
                }
                return mCurrent;
            }
        }

    }


}
