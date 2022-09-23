using ABISoft.BankApp1.Web.Data.Entities;
using ABISoft.BankApp1.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABISoft.BankApp1.Web.Mappings
{
    public class AccountMapper : IAccountMapper
    {
        public Account MaptoAccount(AccountCreateModel accountCreateModel)
        {
            var account = new Account()
            {
                AccountNumber = accountCreateModel.AccountNumber,
                Balance = accountCreateModel.Balance,
                UserId = accountCreateModel.UserId
            };
            return account;
        } 
    }
}
