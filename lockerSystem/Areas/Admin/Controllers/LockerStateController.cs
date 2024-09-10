using lockerSystem.Domain;
using lockerSystem.Models;
using lockerSystem.ViewsModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace lockerSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class LockerStateController : Controller
    {
        private readonly LockerStateDomain _LockerStateDomain;
        public LockerStateController(LockerStateDomain LockerStateDomain)
        {

            _LockerStateDomain = LockerStateDomain;
        }
        public async Task<IActionResult> Index(string seaechString)
        {
            var state = await _LockerStateDomain.GetLockerState();
            if (!String.IsNullOrEmpty(seaechString))
            {
                state = state.Where(n => n.stateAr.Contains(seaechString)
                ||n.stateEn.Contains(seaechString)).ToList();

            }
            return View(state);
        }
        [HttpGet]
        public async Task<IActionResult> add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> add(LockerStateViewsModels state)
        {
            if (ModelState.IsValid)
            {
                string check = await _LockerStateDomain.addLockerState(state);
                if (check == "1")
                    ViewData["Successful"] = "تمت الاضافه بنجاح";
                else
                    ViewData["Falied"] = check;
            }
            await _LockerStateDomain.addLockerState(state);
            return View(state);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return View(await _LockerStateDomain.getlockerstateById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LockerStateViewsModels state)
        {
            if (ModelState.IsValid)
            {
                string check = await _LockerStateDomain.editLockerState(state);
                if (check == "1")
                    ViewData["Successful"] = "تم التعديل بنجاح";
                else
                    ViewData["Falied"] = check;
            }
            //_LockerStateDomain.editLockerState(state);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            string check = await _LockerStateDomain.DeleteLockerState(id);

            if (check == "1")
                ViewData["Successful"] = "تم الحذف بنجاح";
            else
                ViewData["Falied"] = check;
            await _LockerStateDomain.DeleteLockerState(id);
            return View();
        }

    }
}



