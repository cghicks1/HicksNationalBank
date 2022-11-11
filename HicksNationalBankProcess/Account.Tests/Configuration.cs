using System;
using Xunit;
using Autofac;
using Account.Model;

namespace Account.Tests
{
    public class Configuration : Module

    {
        protected override void Load(ContainerBuilder builder)

        {

            // Model

            builder.Register(c => MockAccountDbContext.CreateDbContext())
            .As<AccountDbContext>()
            .InstancePerLifetimeScope();
            // builder.RegisterType<CoaQueries>().As<ICoaQueries>();



        }
    }
}
