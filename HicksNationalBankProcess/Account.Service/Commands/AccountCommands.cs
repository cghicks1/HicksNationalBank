using Account.Model;
using Account.Model.Entities;
using Account.Service.DTOs;
using Account.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Account.Service.Commands
{
    public class AccountCommands : IAccountCommands
    {
        #region Fields
        private readonly AccountDbContext _model;
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        #endregion

        public AccountCommands(AccountDbContext model)
        {
            _model = model;
        }

        //#endregion

        public async Task UpdateAccount(AccountUpdateDTO accountUpdate)

        {
            HicksNationalAccount updatingAccount = await _model.HicksNationalAccounts.FirstOrDefaultAsync(x => x.Id == accountUpdate.AccountId);
            if(updatingAccount == null)
            {
                _logger.Debug("The account was not found.");
                return;
            }
            decimal? withdrawalLimit = null;
            withdrawalLimit = updatingAccount.AccountType.WithdrawalLimit == null ? updatingAccount.Balance: updatingAccount.AccountType.WithdrawalLimit ;
        
            switch (accountUpdate.AccountAction)
            {
                case "TRANSFER":
                    {             
                        HicksNationalAccount transferAccount = await _model.HicksNationalAccounts.FirstOrDefaultAsync(x => x.Id == accountUpdate.TransferAccountId);
                        if (transferAccount == null)
                        {
                            _logger.Debug("The account to be transferred to was not found.");
                            return;
                        }
                        updatingAccount.Balance = updatingAccount.Balance - accountUpdate.RenderedAmount;
                        transferAccount.Balance = transferAccount.Balance + accountUpdate.RenderedAmount;
                        updatingAccount.ModifiedOn = DateTime.UtcNow;
                        transferAccount.ModifiedOn = DateTime.UtcNow;

                        _model.Update(transferAccount);
                    }
                    break;
                case "WITHDRAW":
                    {
                        if (accountUpdate.RenderedAmount > withdrawalLimit)
                        {
                            _logger.Error("The amount requested exceeds the withdrawal limit");
                            return;
                        }
                        updatingAccount.Balance = updatingAccount.Balance - accountUpdate.RenderedAmount;
                        updatingAccount.ModifiedOn = DateTime.UtcNow;
                    }
                    break;
                default:
                    {
                        updatingAccount.Balance = updatingAccount.Balance + accountUpdate.RenderedAmount;
                        updatingAccount.ModifiedOn = DateTime.UtcNow;
                    }
                    break;
            }
            _model.Update(updatingAccount);
            await _model.SaveChangesAsync();

        }

    } }


