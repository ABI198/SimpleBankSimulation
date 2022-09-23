using ABISoft.BankApp1.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABISoft.BankApp1.Web.Data.Interfaces
{
    public interface IAccountRepository
    {
        void Create(Account account);
    }
}
