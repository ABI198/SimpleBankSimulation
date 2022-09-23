using ABISoft.BankApp1.Web.Data.Context;
using ABISoft.BankApp1.Web.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABISoft.BankApp1.Web.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly BankContext _bankContext;
        public Repository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }  

        public void Add(T entity)
        {
            _bankContext.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            _bankContext.Set<T>().Remove(entity);
        }

        public List<T> GetAll()
        {
            return _bankContext.Set<T>().ToList();
        }

        public T GetById(object id)
        {
            return _bankContext.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            //_bankContext.Set<T>().Update(entity);
            _bankContext.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<T> GetQueryable()
        {
            return _bankContext.Set<T>().AsQueryable();
        }
    }
}
