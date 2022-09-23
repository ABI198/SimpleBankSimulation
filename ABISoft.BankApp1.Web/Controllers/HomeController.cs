using ABISoft.BankApp1.Web.Data.Context;
using ABISoft.BankApp1.Web.Data.Interfaces;
using ABISoft.BankApp1.Web.Mappings;
using Microsoft.AspNetCore.Mvc;

namespace ABISoft.BankApp1.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserMapper _userMapper;
        public HomeController(IUserRepository userRepository, IUserMapper userMapper)
        {
            _userRepository = userRepository;
            _userMapper = userMapper;
        }

        public IActionResult Index()
        {
            var userListModelList = _userMapper.MapToUserListModelList(_userRepository.GetAll());
            return View(userListModelList);
        }
    }
}
