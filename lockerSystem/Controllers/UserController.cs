using lockerSystem.Domain;
using lockerSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace lockerSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly UserDomain _userDomain;
        public UserController(UserDomain userDomain) {

            _userDomain = userDomain;
        }
        public IActionResult Index()
        {
            return View(_userDomain.GetAllUsers());
        }
        [HttpGet]
        public IActionResult add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult add(tblUser user)
        {
            _userDomain.addUser(user);  
            return View(user);
        }

    }
}
