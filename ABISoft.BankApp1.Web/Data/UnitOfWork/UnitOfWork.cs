using ABISoft.BankApp1.Web.Data.Context;
using ABISoft.BankApp1.Web.Data.Interfaces;
using ABISoft.BankApp1.Web.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABISoft.BankApp1.Web.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BankContext _bankContext;
        public UnitOfWork(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public IRepository<T> GetRepository<T>() where T : class, new()
        {
            return new Repository<T>(_bankContext);
        }

        public void SaveChanges()
        {
            _bankContext.SaveChanges();
        }
    }
}
