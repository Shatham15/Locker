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
    public class FloorController : Controller
    {
        private readonly FloorDomain _floorDomain;
        private readonly UserDomain _userDomain;
        public FloorController(FloorDomain floorDomain)
        {
            _floorDomain = floorDomain;
        }

        public async Task<IActionResult> Index(string seaechString)
        {
            string gender = User.FindFirst("Gender").Value;
            var floor = await _floorDomain.GetAllFloorByGender(gender);
            if (!String.IsNullOrEmpty(seaechString))
            {
                floor = floor.Where(n => n.BuildingName.Contains(seaechString)).ToList();

            }
            return View(floor);
        }
        public async Task<IActionResult> add()
        {
            string gender = User.FindFirst("Gender").Value;

            ViewBag.Building = new SelectList(await _floorDomain.GetBuildingByGender(gender), "Id", "NameAr");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> add(FloorViewsModels floor)
        {
            string gender = User.FindFirst("Gender").Value;
            ViewBag.Building = new SelectList(await _floorDomain.GetBuildingByGender(gender), "Id", "NameAr");
            if (ModelState.IsValid)
            {
                string check = await _floorDomain.addFloor(floor);
                if (check == "1")
                    ViewData["Successful"] = "تمت عملية الاضافه ";
                else
                    ViewData["Falied"] = check;
            }
            return View(floor);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            string gender = User.FindFirst("Gender").Value;
            ViewBag.Building = new SelectList(await _floorDomain.GetBuildingByGender(gender), "Id", "NameAr");//نفس الاسم اللي بالداتا
            return View(await _floorDomain.getFloorById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FloorViewsModels floor)
        {
            string gender = User.FindFirst("Gender").Value;

            if (ModelState.IsValid)
            {
                string check = await _floorDomain.editFloor(floor);
                if (check == "1")

                    ViewData["Successful"] = " تمت عملية التعديل ";
                else
                    ViewData["Falied"] = check;

            }
            ViewBag.Building = new SelectList(await _floorDomain.GetBuildingByGender(gender), "Id", "NameAr");//نفس الاسم اللي بالداتا

            return View(floor);
        }

        public async Task<IActionResult> delete(Guid id)
        {
            string check = await _floorDomain.deleteFloor(id);
            if (check == "1")

                ViewData["Successful"] = " تمت عملية الحذف ";

            else

                ViewData["Falied"] = check;

            await _floorDomain.deleteFloor(id);
            return View();
        }


    }
}
