using ABISoft.BankApp1.Web.Data.Context;
using ABISoft.BankApp1.Web.Data.Entities;
using ABISoft.BankApp1.Web.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ABISoft.BankApp1.Web.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BankContext _bankContext;
        public UserRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public List<User> GetAll()
        {
            var userList = _bankContext.Users.ToList();
            return userList;
        }

        public User GetById(int id)
        {
            var selectedUser = _bankContext.Users.FirstOrDefault(x => x.Id == id);
            return selectedUser;
        }
    }
}
