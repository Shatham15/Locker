using lockerSystem.Domain;
using lockerSystem.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lockerSystem.Controllers
{
    public class PermissionController : Controller
    {
        private readonly PermissionDomain _domain;
        public PermissionController(PermissionDomain domain)
        {
            _domain = domain;
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
        [ValidateAntiForgeryToken]

        public IActionResult add(PermissionViweModel permission)
        {
            ViewBag.roles = new SelectList(_domain.getRoles(), "Id", "RoleNameAr");
            if (ModelState.IsValid)
            {
                string check = _domain.addPermission(permission);
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

        public IActionResult Edit(PermissionViweModel permission)
        {
            ViewBag.roles = new SelectList(_domain.getRoles(), "Id", "RoleNameAr");

            if (ModelState.IsValid)
            {
                string check = _domain.editUser(permission);
                if (check == "1")
                    ViewData["Successful"] = "تم التعديل  بنجاح";
                else
                    ViewData["Falied"] = check;
                _domain.editUser(permission);
            }
            return View(permission);

        }

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


    }
}
