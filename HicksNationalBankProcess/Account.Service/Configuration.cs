using Account.Model;
using Account.Service.Commands;
using Account.Service.Interfaces;
using Autofac;
using System;

namespace Account.Service
{
    public class Configuration : Module
    {
        private readonly string _dbConnString;

        public Configuration(string dbConnString)
        {
            _dbConnString = dbConnString ?? throw new ArgumentNullException(nameof(dbConnString));
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => AccountDbContext.NewAccountDbContext(_dbConnString))
         .As<AccountDbContext>()
         .InstancePerLifetimeScope();

          builder.RegisterType<AccountCommands>().As<IAccountCommands>();

        }

    }
}
