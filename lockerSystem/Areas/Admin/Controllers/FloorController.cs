using lockerSystem.Domain;
using lockerSystem.Models;
using lockerSystem.ViewsModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace lockerSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class FloorController : Controller
    {
        private readonly FloorDomain _floorDomain;
        public FloorController(FloorDomain floorDomain)
        {
            _floorDomain = floorDomain;
        }

        public async Task<IActionResult> Index(string seaechString)
        {
            var floor = await _floorDomain.GetAllFloor();
            if (!String.IsNullOrEmpty(seaechString))
            {
                floor = floor.Where(n => n.BuildingName.Contains(seaechString)).ToList();

            }
            return View(floor);
        }
        public async Task<IActionResult> addFloor()
        {
            ViewBag.Building = new SelectList(await _floorDomain.GetBuilding(), "Id", "NameAr");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> addFloor(FloorViewsModels floor)
        {
            ViewBag.Building = new SelectList(await _floorDomain.GetBuilding(), "Id", "NameAr");
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
            ViewBag.Building = new SelectList(await _floorDomain.GetBuilding(), "Id", "NameAr");//نفس الاسم اللي بالداتا
            return View(await _floorDomain.getFloorById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FloorViewsModels floor)
        {
            if (ModelState.IsValid)
            {
                string check = await _floorDomain.editFloor(floor);
                if (check == "1")

                    ViewData["Successful"] = " تمت عملية التعديل ";
                else
                    ViewData["Falied"] = check;

            }
            ViewBag.Building = new SelectList(await _floorDomain.GetBuilding(), "Id", "NameAr");//نفس الاسم اللي بالداتا

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
