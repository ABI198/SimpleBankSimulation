using ABISoft.BankApp1.Web.Data.Interfaces;

namespace ABISoft.BankApp1.Web.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : class, new();
        void SaveChanges();
    }
}