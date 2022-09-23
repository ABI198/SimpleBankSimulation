using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABISoft.BankApp1.Web.Data.Interfaces
{
    public interface IRepository<T> where T : class, new()
    {
        void Add(T entity);
        void Remove(T entity);
        List<T> GetAll();
        T GetById(object id);
        void Update(T entity);
        IQueryable<T> GetQueryable();
    }
}
