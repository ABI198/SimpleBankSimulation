using ABISoft.BankApp1.Web.Data.Entities;
using ABISoft.BankApp1.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABISoft.BankApp1.Web.Mappings
{
    public class UserMapper : IUserMapper
    {
        public List<UserListModel> MapToUserListModelList(List<User> userList)
        {
            var userListModelList = userList.Select(x => new UserListModel()
            {
               Id = x.Id, 
               Firstname = x.Firstname,
               Lastname = x.Lastname
            }).ToList();
            return userListModelList;
        }
        
        public UserListModel MapToUserListModel(User user)
        {
            var userListModel = new UserListModel()
            {
                Id = user.Id,
                Firstname = user.Firstname,
                Lastname = user.Lastname
            };
            return userListModel;
        }
    }
}
