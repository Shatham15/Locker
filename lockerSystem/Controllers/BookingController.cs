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


        public BookingController(BookingDomain domain,BuildingDomain buildingDomain, FloorDomain floorDomain)
        {
            _domain = domain;
            _buildingDomain = buildingDomain;
            _floorDomain = floorDomain;
        }

        public async Task<IActionResult> Index()
        {
            
            return View(await _domain.GetAllbooking());
        }

        [HttpGet]
        public async Task<IActionResult> add()
        {
            ViewBag.Building = new SelectList(await _buildingDomain.GetAllBuildings(), "Guid", "NameAr");/// كيف بيجيبه وهو ماله ارتباط مباشر مع جدول البيلدينق؟؟
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> add(BookingViewsModels book)
        {
            ViewBag.Building = new SelectList(await _buildingDomain.GetAllBuildings(), "Guid", "NameAr");
            return View();
        }
        public async Task<IEnumerable<FloorViewsModels>> getFloorByBuildingId(Guid id)
        {
            return await _floorDomain.getFloorByBuildinGuid(id);
        }


    }
}
