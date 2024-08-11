using lockerSystem.Domain;
using lockerSystem.Models;
using lockerSystem.ViewsModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace lockerSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly UserDomain _userDomain;
        public UserController(UserDomain userDomain)
        {

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
        public IActionResult add(UserViweModele user)
        {
            if (ModelState.IsValid)
            {
                _userDomain.addUser(user);
                return RedirectToAction("Index");
            }
            return View(user);



        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            try
            {
                if (User.Identity.IsAuthenticated){
                    string UserName = User.FindFirst(ClaimTypes.Name).Value;
                    return RedirectToAction("Index", "Home");

                }
                else {
                    return View();

                }

            }
            catch
            {
                return View();
            }

        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserViweModele UserInfo)
        {
            try
            {
                UserViweModele User = _userDomain.GetUsersForLogin(UserInfo);
                if (User==null)
                {
                    ViewData["Login_error"] = "خطأ: اسم المستخدم أو كلمة المرور غير صحيحة";
                    return View();
                }
                else
                {

                    var identity = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Name, User.fullName),
                    new Claim(ClaimTypes.Role, User.userType),
                    new Claim(ClaimTypes.NameIdentifier, User.Id.ToString()),
                    new Claim(ClaimTypes.GivenName, User.fullName)

                }, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        principal);
                    if(User.userType == "Admin"|| User.userType=="student"|| User.userType=="staff")
                    return RedirectToAction("Index", "Home");
                    else
                        return RedirectToAction("authorization", "Home");

                }
            }
            catch
            {
                ViewData["Login_error"] = "خطأ: اسم المستخدم أو كلمة المرور غير صحيحة";
                return View();
            }

        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(UserController.Login), "User");
        }


    }
}
