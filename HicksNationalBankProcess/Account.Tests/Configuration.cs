using System;
using Xunit;
using Autofac;
using Account.Model;
using Account.Service.Commands;
using Account.Service.Interfaces;

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
            builder.RegisterType<AccountCommands>().As<IAccountCommands>();

        }
    }
}
