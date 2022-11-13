using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Xunit;
using Account.Model;
using Account.Service.Interfaces;
using Account.Service.DTOs;

namespace Account.Tests
{
    public class AccountCommandsTests
    {
        [Fact]

        public async void Deposit500IntoCheckingAccount_WillIncreaseAccountBalanceBy500()
        {
            using (var scope = DependencyResolver.Current.BeginLifetimeScope())
            {
                var dbContext = scope.GetService<AccountDbContext>();
                dbContext.HicksNationalAccountOwners.AddRange(MockDataBuilder.GetAccountOwners());
                dbContext.HicksNationalAccounts.AddRange(MockDataBuilder.GetAccounts());
                dbContext.HicksNationalAccountOwnerLinkages.AddRange(MockDataBuilder.GetAccountLinkages());
                dbContext.HicksNationalAccountTypes.AddRange(MockDataBuilder.GetAccountTypes());

                await dbContext.SaveChangesAsync();
                var commands = scope.GetService<IAccountCommands>();

                var dto = new AccountUpdateDTO() { AccountId = 1, AccountAction = "DEPOSIT", RenderedAmount = 300, TransferAccountId = null };

                await commands.UpdateAccount(dto);
                var test = await dbContext.HicksNationalAccounts.FirstOrDefaultAsync(x => x.Id == 1);

                Assert.NotNull(test);
                Assert.Equal(test.Balance, 900);
            }
        }
        [Fact]

        public async void Withdraw500FromCheckingAccount_WillDecreaseAccountBalanceBy500()
        {
            using (var scope = DependencyResolver.Current.BeginLifetimeScope())
            {
                var dbContext = scope.GetService<AccountDbContext>();
                dbContext.HicksNationalAccountOwners.AddRange(MockDataBuilder.GetAccountOwners());
                dbContext.HicksNationalAccounts.AddRange(MockDataBuilder.GetAccounts());
                dbContext.HicksNationalAccountOwnerLinkages.AddRange(MockDataBuilder.GetAccountLinkages());
                dbContext.HicksNationalAccountTypes.AddRange(MockDataBuilder.GetAccountTypes());

                await dbContext.SaveChangesAsync();
                var commands = scope.GetService<IAccountCommands>();

                var dto = new AccountUpdateDTO() { AccountId = 1, AccountAction = "WITHDRAW", RenderedAmount = 300, TransferAccountId = null };

                await commands.UpdateAccount(dto);
                var test = await dbContext.HicksNationalAccounts.FirstOrDefaultAsync(x => x.Id == 1);

                Assert.NotNull(test);
                Assert.Equal(test.Balance, 300);
            }
        }
        [Fact]
        public async void Withdraw400FromIndividualAccount_WillDecreaseBalanceBy400()
        {
            using (var scope = DependencyResolver.Current.BeginLifetimeScope())
            {
                var dbContext = scope.GetService<AccountDbContext>();
                dbContext.HicksNationalAccountOwners.AddRange(MockDataBuilder.GetAccountOwners());
                dbContext.HicksNationalAccounts.AddRange(MockDataBuilder.GetAccounts());
                dbContext.HicksNationalAccountOwnerLinkages.AddRange(MockDataBuilder.GetAccountLinkages());
                dbContext.HicksNationalAccountTypes.AddRange(MockDataBuilder.GetAccountTypes());

                await dbContext.SaveChangesAsync();
                var commands = scope.GetService<IAccountCommands>();

                var dto = new AccountUpdateDTO() { AccountId = 1, AccountAction = "WITHDRAW", RenderedAmount = 300, TransferAccountId = null };

                await commands.UpdateAccount(dto);
                var test = await dbContext.HicksNationalAccounts.FirstOrDefaultAsync(x => x.Id == 2);

                Assert.NotNull(test);
                Assert.Equal(test.Balance, 8000);
            }
        }

            [Fact]

            public async void Withdraw800FromIndividualAccount_WillNotDecreaseBalance_DueToWithdrawalLimitOf500()
            {
                using (var scope = DependencyResolver.Current.BeginLifetimeScope())
                {
                    var dbContext = scope.GetService<AccountDbContext>();
                    dbContext.HicksNationalAccountOwners.AddRange(MockDataBuilder.GetAccountOwners());
                    dbContext.HicksNationalAccounts.AddRange(MockDataBuilder.GetAccounts());
                    dbContext.HicksNationalAccountOwnerLinkages.AddRange(MockDataBuilder.GetAccountLinkages());
                    dbContext.HicksNationalAccountTypes.AddRange(MockDataBuilder.GetAccountTypes());

                    await dbContext.SaveChangesAsync();
                    var commands = scope.GetService<IAccountCommands>();

                    var dto = new AccountUpdateDTO() { AccountId = 1, AccountAction = "WITHDRAW", RenderedAmount = 300, TransferAccountId = null };

                    await commands.UpdateAccount(dto);
                    var test = await dbContext.HicksNationalAccounts.FirstOrDefaultAsync(x => x.Id == 2);

                    Assert.NotNull(test);
                    Assert.Equal( 8000, test.Balance);
                }
            }
        [Fact]

        public async void Withdraw90000FromCorporateAccount_WillNotDecreaseBalance_DueToBeingMoreThanBalance()
        {
            using (var scope = DependencyResolver.Current.BeginLifetimeScope())
            {
                var dbContext = scope.GetService<AccountDbContext>();
                dbContext.HicksNationalAccountOwners.AddRange(MockDataBuilder.GetAccountOwners());
                dbContext.HicksNationalAccounts.AddRange(MockDataBuilder.GetAccounts());
                dbContext.HicksNationalAccountOwnerLinkages.AddRange(MockDataBuilder.GetAccountLinkages());
                dbContext.HicksNationalAccountTypes.AddRange(MockDataBuilder.GetAccountTypes());

                await dbContext.SaveChangesAsync();
                var commands = scope.GetService<IAccountCommands>();

                var dto = new AccountUpdateDTO() { AccountId = 1, AccountAction = "WITHDRAW", RenderedAmount = 90000, TransferAccountId = null };

                await commands.UpdateAccount(dto);
                var test = await dbContext.HicksNationalAccounts.FirstOrDefaultAsync(x => x.Id == 3);

                Assert.NotNull(test);
                Assert.Equal( 400000, test.Balance);
            }
        }
        [Fact]

        public async void Transfer500FromIndividualAccountToChecking_WillDecreaseBalanceBy500_AndIncreaseCheckingBalanceBy500()
        {
            using (var scope = DependencyResolver.Current.BeginLifetimeScope())
            {
                var dbContext = scope.GetService<AccountDbContext>();
                dbContext.HicksNationalAccountOwners.AddRange(MockDataBuilder.GetAccountOwners());
                dbContext.HicksNationalAccounts.AddRange(MockDataBuilder.GetAccounts());
                dbContext.HicksNationalAccountOwnerLinkages.AddRange(MockDataBuilder.GetAccountLinkages());
                dbContext.HicksNationalAccountTypes.AddRange(MockDataBuilder.GetAccountTypes());

                await dbContext.SaveChangesAsync();
                var commands = scope.GetService<IAccountCommands>();

                var dto = new AccountUpdateDTO() { AccountId = 2, AccountAction = "TRANSFER", RenderedAmount = 500, TransferAccountId = 1 };

                await commands.UpdateAccount(dto);
                var testIndividual = await dbContext.HicksNationalAccounts.FirstOrDefaultAsync(x => x.Id == 2);
                var testChecking = await dbContext.HicksNationalAccounts.FirstOrDefaultAsync(x => x.Id == 1);

                Assert.NotNull(testIndividual);
                Assert.NotNull(testChecking);

                Assert.Equal(7500, testIndividual.Balance);
                Assert.Equal(1100, testChecking.Balance);

            }
        }
    }
}
