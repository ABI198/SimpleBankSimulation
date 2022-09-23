using ABISoft.BankApp1.Web.Data.Entities;
using ABISoft.BankApp1.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABISoft.BankApp1.Web.Mappings
{
    public interface IUserMapper
    {
        List<UserListModel> MapToUserListModelList(List<User> userList);
        UserListModel MapToUserListModel(User user);
    }
}
