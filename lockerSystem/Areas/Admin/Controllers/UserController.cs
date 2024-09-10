using lockerSystem.Domain;
using lockerSystem.Models;
using lockerSystem.ViewsModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using lockerSystem.Migrations;
namespace lockerSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserDomain _userDomain;
        private readonly PermissionDomain _permissionDomain;
        public UserController(UserDomain userDomain, PermissionDomain permissionDomain)
        {

            _userDomain = userDomain;
            _permissionDomain = permissionDomain;
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _userDomain.GetAllUsers());
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> add(UserViweModele user)
        {
            if (ModelState.IsValid)
            {
                await _userDomain.addUser(user);
                return RedirectToAction("Index");
            }
            return View(user);



        }
        //
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    string UserName = User.FindFirst(ClaimTypes.Name).Value;
                    return RedirectToAction("Index", "Home");

                }
                else
                {
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
                UserViweModele User = await _userDomain.GetUsersForLogin(UserInfo);
                if (User == null)
                {
                    ViewData["Login_error"] = "خطأ: اسم المستخدم أو كلمة المرور غير صحيحة";
                    return View();
                }
                else
                {
                    string Role = "";
                    tblPermission model = _permissionDomain.getUserModelByUserName(UserInfo.email);
                    if (model == null)
                        Role = "NoRole";
                    else
                        Role = model.Role.RoleNameEn;
                    var identity = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Name, User.fullName),
                                        new Claim(ClaimTypes.Email, User.email),
                                        new Claim(ClaimTypes.Gender, User.gender),

                    new Claim(ClaimTypes.Role, Role),
                    new Claim(ClaimTypes.NameIdentifier, User.Id.ToString()),


                    new Claim(ClaimTypes.GivenName, User.fullName)

                }, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        principal);
                    if (Role == "Admin")
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    else
                        return RedirectToAction("Index", "Home");

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
