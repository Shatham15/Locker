using lockerSystem.Domain;
using lockerSystem.Models;
using lockerSystem.ViewsModels;
using Microsoft.AspNetCore.Mvc;

namespace lockerSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly UserDomain _userDomain;
        public UserController(UserDomain userDomain) {

            _userDomain = userDomain;
        }
        public async Task<  IActionResult > Index()
        {
            return View( await _userDomain.GetAllUsers());
        }
        [HttpGet]
        public IActionResult add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult add(UserViewsModels user)
        {
            if(ModelState.IsValid)
            {
                _userDomain.addUser(user);
            }
            return View(user);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_userDomain.getUserById(id));
        }
        [HttpPost]
        public IActionResult Edit(tblUser user)
        {
            _userDomain.editUser(user);
            return View(user);
        }

    }
}
