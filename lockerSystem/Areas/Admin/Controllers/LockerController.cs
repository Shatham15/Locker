using lockerSystem.Domain;
using lockerSystem.Migrations;
using lockerSystem.Models;
using lockerSystem.ViewsModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
namespace lockerSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class LockerController : Controller
    {
        private readonly LockerDomain _LockerDomain;
        private readonly BuildingDomain _BuildingDomain;
        private readonly FloorDomain _FloorDomain;
        private readonly LockerStateDomain _LockerStateDomain;

        public LockerController(LockerDomain LockerDomain, BuildingDomain buildingDomain, FloorDomain floorDomain, LockerStateDomain LockerStateDomain)
        {
            _BuildingDomain = buildingDomain;
            _FloorDomain = floorDomain;
            _LockerDomain = LockerDomain;
            _LockerStateDomain = LockerStateDomain;

        }



        public async Task<IActionResult> Index(int? searchNumber)
        {
            var locker = await _LockerDomain.GetAllLockers();
            if (searchNumber.HasValue)
            {
                locker = locker.Where(l => l.no == searchNumber.Value).ToList();

            }
            //return View(await _LockerDomain.GetAllLockers());
            return View(locker);
        }
        public async Task<IActionResult> add()
        {
            ViewBag.Floor = new SelectList(await _FloorDomain.GetAllFloor(), "FloorId", "FloorNo");
            ViewBag.Building = new SelectList(await _BuildingDomain.GetAllBuildings(), "BuildingId", "NameAr");
            ViewBag.LockerState = new SelectList(await _LockerStateDomain.GetLockerState(), "LockerStateId", "stateAr");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> add(LockerViewsModels Locker)
        {
            ViewBag.Floor = new SelectList(await _FloorDomain.GetAllFloor(), "FloorId", "FloorNo");
            ViewBag.Building = new SelectList(await _BuildingDomain.GetAllBuildings(), "BuildingId", "NameAr");
            ViewBag.LockerState = new SelectList(await _LockerStateDomain.GetLockerState(), "LockerStateId", "stateAr");
            if (ModelState.IsValid)
            {
                string check = await _LockerDomain.addLocker(Locker);
                if (check == "1")
                    ViewData["Successful"] = "تمت الاضافة بنجاح";
                else
                    ViewData["Falied"] = check;
            }
            return View(Locker);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            ViewBag.Floor = new SelectList(await _FloorDomain.GetAllFloor(), "FloorId", "FloorNo");
            ViewBag.Building = new SelectList(await _BuildingDomain.GetAllBuildings(), "BuildingId", "NameAr");
            ViewBag.LockerState = new SelectList(await _LockerStateDomain.GetLockerState(), "LockerStateId", "stateAr");
            return View(await _LockerDomain.getLockerById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LockerViewsModels Locker)
        {
            string check = await _LockerDomain.editLocker(Locker);
            if (check == "1")

                ViewData["Successful"] = " تم التعديل بنجاح";
            else
                ViewData["Falied"] = check;

            ViewBag.Floor = new SelectList(await _FloorDomain.GetAllFloor(), "FloorId", "FloorNo");
            ViewBag.Building = new SelectList(await _BuildingDomain.GetAllBuildings(), "BuildingId", "NameAr");
            ViewBag.LockerState = new SelectList(await _LockerStateDomain.GetLockerState(), "LockerStateId", "stateAr");
            await _LockerDomain.editLocker(Locker);
            return View(Locker);
        }


        public async Task<IActionResult> delete(Guid id)
        {
            string check = await _LockerDomain.deleteLocker(id);
            if (check == "1")

                ViewData["Successful"] = " تم الحذف بنجاح";

            else

                ViewData["Falied"] = check;


            await _LockerDomain.deleteLocker(id);
            return View();
        }


    }
}