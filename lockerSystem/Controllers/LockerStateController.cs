using lockerSystem.Domain;
using lockerSystem.Models;
using lockerSystem.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace lockerSystem.Controllers
{
    public class LockerStateController : Controller
    {
        private readonly LockerStateDomain _LockerStateDomain;
        public LockerStateController(LockerStateDomain LockerStateDomain)
        {

            _LockerStateDomain = LockerStateDomain;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _LockerStateDomain.GetLockerState());
        }
        [HttpGet]
        public IActionResult add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult add(LockerStateViewsModels state)
        {
            if (ModelState.IsValid)
            {
                string check = _LockerStateDomain.addLockerState(state);
                if (check == "1")
                    ViewData["Successful"] = "تمت عملية الاضافه بنجاح";
                else
                    ViewData["Falied"] = check;
            }
            return View(state);
        }


        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            return View(_LockerStateDomain.getlockerstateById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(LockerStateViewsModels state)
        {

            string check = _LockerStateDomain.editLockerState(state);
            if (check == "1")
                ViewData["Successful"] = "تم التعديل بنجاح";
            else
                ViewData["Falied"] = check;

            _LockerStateDomain.editLockerState(state);
            return View(state);
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            string check = _LockerStateDomain.DeleteLockerState(id);

            if (check == "1")
                ViewData["Successful"] = "تم الحذف بنجاح";
            else
                ViewData["Falied"] = check;
            _LockerStateDomain.DeleteLockerState(id);
            return View();
        }

    }
}



