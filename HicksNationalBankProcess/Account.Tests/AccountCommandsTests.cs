using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Account.Tests
{
    public class AccountCommandsTests
    {
        [Fact]

        public async void Deposit500IntoCheckingAccount_WithIdOf1_WillIncreaseAccountBalanceBy500()
        {
            using (var scope = DependencyResolver.Current.BeginLifetimeScope())
            {
                var dbContext = scope.g

                dbContext.Hicks AddRange(MockDataBuilder.GetAccountOwners());
                dbContext.Cocoms.AddRange(MockDataBuilder.GetAccountLinkages());

                dbContext.Readinesses.AddRange(MockDataBuilder.GetAccountOwners());

            }
        }
    }
}
