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
        public async Task<IActionResult> Index(string seaechString)
        {
            var management = await _managementdomain.GetAllMangement();
            if (!String.IsNullOrEmpty(seaechString))
            {
                management = management.Where(n => n.name.Contains(seaechString)).ToList();

            }
            return View(management);
        }
       
        [HttpGet]
        public async Task<IActionResult> add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> add(ManagementViewsModels management)
        {


            if (ModelState.IsValid)
            {
                string check = await _managementdomain.addMangement(management);
                if (check == "1")

                    ViewData["Successful"] = "تمت الاضافة بنجاح";

                else

                    ViewData["Falied"] = check;
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> edit(Guid id)
        {

            return View( await _managementdomain.getManagementById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> edit(ManagementViewsModels management)
        {



            if (ModelState.IsValid)
            {
                string check = await _managementdomain.editManagement(management);
                if (check == "1")

                    ViewData["Successful"] = "تم التعديل بنجاح";

                else

                    ViewData["Falied"] = check;
            }
            return View();



        }

        public async Task<IActionResult> Delete(Guid id)
        {

            
            string check = await _managementdomain.DeleteManagement(id);
            if (check == "1")

                ViewData["Successful"] = "تم الحذف بنجاح";

            else

                ViewData["Falied"] = check;

            await _managementdomain.DeleteManagement(id);
            return View();
        }
    }







}
