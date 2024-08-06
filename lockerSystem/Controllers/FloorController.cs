using lockerSystem.Domain;
using lockerSystem.Models;
using lockerSystem.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lockerSystem.Controllers
{
    public class FloorController : Controller
    {
        private readonly FloorDomain _floorDomain;
        public FloorController(FloorDomain floorDomain)
        {
            _floorDomain = floorDomain;
        }



        public async Task<IActionResult> Index()
        {
            return View(await _floorDomain.GetAllFloor());
        }
        public IActionResult addFloor()
        {
            ViewBag.Building = new SelectList(_floorDomain.GetBuilding(), "Id", "NameAr");
            return View();
        }
        [HttpPost]

        public IActionResult addFloor(FloorViewsModels floor)
        {
            ViewBag.Building = new SelectList(_floorDomain.GetBuilding(), "Id", "NameAr");
            if (ModelState.IsValid)
            {
                string check = _floorDomain.addFloor(floor);
                if (check == "1")
                    ViewData["Successful"] = "تمت عملية الاضافه بنجاح";
                else
                    ViewData["Falied"] = check;
            }
            return View(floor);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            ViewBag.Building = new SelectList(_floorDomain.GetBuilding(), "Id", "NameAr");//نفس الاسم اللي بالداتا
            return View(_floorDomain.getFloorById(id));
        }
        [HttpPost]
        public IActionResult Edit(FloorViewsModels floor)
        {
            string check = _floorDomain.editFloor(floor);
            if (check == "1")

                ViewData["Successful"] = " تمت عملية التعديل بنجاح";
            else
                ViewData["Falied"] = check;

            ViewBag.Building = new SelectList(_floorDomain.GetBuilding(), "Id", "NameAr");//نفس الاسم اللي بالداتا
            _floorDomain.editFloor(floor);
            return View(floor);
        }


        public IActionResult delete(Guid id)
        {
            string check = _floorDomain.deleteFloor(id);
            if (check == "1")

                ViewData["Successful"] = " تمت عملية الحذف بنجاح";

            else

                ViewData["Falied"] = check;


            _floorDomain.deleteFloor(id);
            return View();
        }


    }
}
