using lockerSystem.Domain;
using lockerSystem.Models;
using lockerSystem.ViewModels;
using lockerSystem.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security;

namespace lockerSystem.Controllers
{
    //اضيفي async  على كل الفنكشن؟؟
    public class PermissionController : Controller
    {
        private readonly PermissionDomain _domain;
        private readonly UserDomain _userDomain;
        public PermissionController(PermissionDomain domain, UserDomain userDomain)
        {
            _domain = domain;
            _userDomain = userDomain;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _domain.getpermissions());
        }
        [HttpGet]
        public IActionResult add()
        {
            ViewBag.roles = new SelectList(_domain.getRoles(), "Id", "RoleNameAr");//اي اسم
            return View();
        }
        [HttpPost]
        //Validation??
        public async Task<IActionResult> add(PermissionViewsModels permission)
        {
            ViewBag.roles = new SelectList(_domain.getRoles(), "Id", "RoleNameAr");
            if (ModelState.IsValid)
            {
                string check = await _domain.addPermission(permission);
                if (check == "1")
                    ViewData["Successful"] = "تمت الاضافة بنجاح";
                else
                    ViewData["Falied"] = check;
            }
            return View(permission);

        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            ViewBag.roles = new SelectList(_domain.getRoles(), "Id", "RoleNameAr");
            return View(_domain.getUserById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(PermissionViewsModels permission)
        {
            ViewBag.roles = new SelectList(_domain.getRoles(), "Id", "RoleNameAr");

            if (ModelState.IsValid)
            {
                string check = _domain.editUser(permission);
                if (check == "1")
                    ViewData["Successful"] = "تم التعديل  بنجاح";
                else
                    ViewData["Falied"] = check;
                //هل يحتاج هذي الجملة هنا اتوقع مالها داعي ؟؟
                _domain.editUser(permission);
            }
            return View(permission);

        }
        //تغير اسم الفنكشن الى دليت؟؟
        public IActionResult removePermission(Guid id)
        {  
            string check = _domain.removeUser(id);
            if (check == "1")

                ViewData["Successful"] = "تم الحذف بنجاح";


            else

                ViewData["Falied"] = check;


            _domain.removeUser(id);
            return View();

            //dff
        }
        public async Task<UserViweModele> getUserInfo(string id)
        {
            return await _userDomain.GetlUserModelByUserName(id);
        }


    }
}
