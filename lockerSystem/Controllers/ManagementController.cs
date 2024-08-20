using lockerSystem.Domain;
using lockerSystem.Models;
using lockerSystem.ViewsModels;
using Microsoft.AspNetCore.Mvc;

namespace lockerSystem.Controllers
{
    public class ManagementController : Controller
    {
        private readonly ManagementDomain _managementdomain;

        public ManagementController(ManagementDomain managementdomain)
        {
            _managementdomain = managementdomain;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _managementdomain.GetAllMangement());
        }
        [HttpGet]
        public IActionResult add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult add(ManagementViewsModels management)
        {


            if (ModelState.IsValid)
            {
                string check = _managementdomain.addMangement(management);
                if (check == "1")

                    ViewData["Successful"] = "تمت الاضافة بنجاح";

                else

                    ViewData["Falied"] = check;
            }
            return View();

        }

        [HttpGet]
        public IActionResult edit(Guid id)
        {

            return View(_managementdomain.getManagementById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult edit(ManagementViewsModels management)
        {



            if (ModelState.IsValid)
            {
                string check = _managementdomain.editManagement(management);
                if (check == "1")

                    ViewData["Successful"] = "تم التعديل بنجاح";

                else

                    ViewData["Falied"] = check;
            }
            return View();



        }

        public IActionResult Delete(Guid id)
        {

            
            string check = _managementdomain.DeleteManagement(id);
            if (check == "1")

                ViewData["Successful"] = "تم الحذف بنجاح";

            else

                ViewData["Falied"] = check;

            _managementdomain.DeleteManagement(id);
            return View();
        }
    }







}
