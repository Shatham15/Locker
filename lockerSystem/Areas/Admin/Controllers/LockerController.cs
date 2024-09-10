using lockerSystem.Domain;
using lockerSystem.Models;
using lockerSystem.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lockerSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LockerController : Controller
    {
        private readonly LockerDomain _LockerDomain;
        private readonly BuildingDomain _BuildingDomain;
        private readonly FloorDomain _FloorDomain;
        private readonly LockerStateDomain _LockerStateDomain;

        public LockerController(LockerDomain LockerDomain, BuildingDomain buildingDomain, FloorDomain floorDomain,  LockerStateDomain LockerStateDomain)
        {
            _BuildingDomain = buildingDomain;
            _FloorDomain = floorDomain;
            _LockerDomain = LockerDomain;
            _LockerStateDomain = LockerStateDomain;

        }



        public async Task<IActionResult> Index()
        {
            return View(await _LockerDomain.GetAllLockers());
        }
        public async Task<IActionResult> add()
        {
            ViewBag.Floor = new SelectList(await _LockerDomain.GetFloor(), "Guid", "no");
            ViewBag.Building = new SelectList(await _BuildingDomain.GetAllBuildings(), "Guid", "no");
            ViewBag.LockerState = new SelectList(await _LockerStateDomain.GetLockerState(), "Guid", "stateAr");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> add(LockerViewsModels Locker)
        {
            ViewBag.Floor = new SelectList(await _LockerDomain.GetFloor(), "Guid", "no");
            ViewBag.Building = new SelectList(await _BuildingDomain.GetAllBuildings(), "Guid", "no");
            ViewBag.LockerState = new SelectList(await _LockerStateDomain.GetLockerState(), "Guid", "stateAr");
            if (ModelState.IsValid)
            {
                string check = await _LockerDomain.addLocker(Locker);
                if (check == "1")
                    ViewData["Successful"] = "تمت عملية الاضافه بنجاح";
                else
                    ViewData["Falied"] = check;
            }
            return View(Locker);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            ViewBag.Floor = new SelectList(await _LockerDomain.GetFloor(), "Guid", "no");
            ViewBag.Building = new SelectList(await _BuildingDomain.GetAllBuildings(), "Guid", "no");
            ViewBag.LockerState = new SelectList(await _LockerStateDomain.GetLockerState(), "Guid", "stateAr");
            return View(await _LockerDomain.getLockerById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LockerViewsModels Locker)
        {
            string check = await _LockerDomain.editLocker(Locker);
            if (check == "1")

                ViewData["Successful"] = " تمت عملية التعديل بنجاح";
            else
                ViewData["Falied"] = check;

            ViewBag.Floor = new SelectList(await _LockerDomain.GetFloor(), "Guid", "no");
            ViewBag.Building = new SelectList(await _BuildingDomain.GetAllBuildings(), "Guid", "no");
            ViewBag.LockerState = new SelectList(await _LockerStateDomain.GetLockerState(), "Guid", "stateAr");
            await _LockerDomain.editLocker(Locker);
            return View(Locker);
        }


        public async Task<IActionResult> delete(Guid id)
        {
            string check = await _LockerDomain.deleteLocker(id);
            if (check == "1")

                ViewData["Successful"] = " تمت عملية الحذف بنجاح";

            else

                ViewData["Falied"] = check;


            await _LockerDomain.deleteLocker(id);
            return View();
        }


    }
}