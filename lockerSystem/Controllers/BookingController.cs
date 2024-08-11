using lockerSystem.Domain;
using lockerSystem.Models;
using lockerSystem.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lockerSystem.Controllers
{
    public class BookingController : Controller
    {
        private readonly BookingDomain _domain;
        private readonly BuildingDomain _buildingDomain;
        private readonly FloorDomain _floorDomain;


        public BookingController(BookingDomain domain)
        {
            _domain = domain;
        }

        public async Task<IActionResult> Index()
        {
            
            return View(await _domain.GetAllbooking());
        }

        [HttpGet]
        public async IActionResult add()
        {
            ViewBag.Building = new SelectList(await _buildingDomain.GetAllBuildings(), "Id" , "NameAr");/// كيف بيجيبه وهو ماله ارتباط مباشر مع جدول البيلدينق؟؟
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> add(BookingViewsModels book)
        {
            ViewBag.Building = new SelectList(await _buildingDomain.GetAllBuildings(), "Id", "NameAr"); /// كيف بيجيبه وهو ماله ارتباط مباشر مع جدول البيلدينق؟؟
            //ViewBag.book = new SelectList(_domain.getIdBook(), "Id", "NameAr");
            return View();
        }
        public FloorViewsModels getFloorByBuildingId(int id)
        {
            return _floorDomain.getFloorByBuildingId(id);
        }


    }
}
