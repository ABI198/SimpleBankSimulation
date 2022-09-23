using ABISoft.BankApp1.Web.Data.Context;
using ABISoft.BankApp1.Web.Data.Entities;
using ABISoft.BankApp1.Web.Data.Interfaces;

namespace ABISoft.BankApp1.Web.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankContext _bankContext;
        public AccountRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public void Create(Account account)
        {
            _bankContext.Accounts.Add(account);
            _bankContext.SaveChanges();
        }
    }
}
