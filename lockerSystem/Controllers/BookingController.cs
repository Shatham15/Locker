using lockerSystem.Domain;
using lockerSystem.Models;
using lockerSystem.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security;
using System.Security.Claims;

namespace lockerSystem.Controllers
{
    public class BookingController : Controller
    {
        private readonly BookingDomain _domain;
        private readonly BuildingDomain _buildingDomain;
        private readonly FloorDomain _floorDomain;
        private readonly LockerDomain _lockerDomain;


        public BookingController(BookingDomain domain, BuildingDomain buildingDomain, FloorDomain floorDomain, LockerDomain lockerDomain)
        {
            _domain = domain;
            _buildingDomain = buildingDomain;
            _floorDomain = floorDomain;
            _lockerDomain = lockerDomain;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string Successful, string Falied)//index search
        {
            ViewData["Successful"] = Successful;
            ViewData["Falied"] = Falied;
            //var booking = await _buildingDomain.GetAllBuildings();
            ViewBag.Building = new SelectList(await _buildingDomain.GetAllBuildings(), "Guid", "NameAr");
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Guid? BuildingGuid, Guid? FloorGuid)
        {
            ViewBag.Building = new SelectList(await _buildingDomain.GetAllBuildings(), "Guid", "NameAr", BuildingGuid);
            //ViewData["locker"];
            return View(await _lockerDomain.getLockerwithFilter(BuildingGuid, FloorGuid));
        }

        public async Task<IActionResult> orders()//index
        {

            return View(await _domain.GetAllbooking());
        }

        [HttpGet]
        public async Task<IActionResult> SubmitOrder(Guid id)//add
        {
            string Successful = "";
            string Falied = "";
            ViewBag.Building = new SelectList(await _buildingDomain.GetAllBuildings(), "Guid", "NameAr");
            if (ModelState.IsValid)
            {
                string check = _domain.AddBooking(id, User.FindFirst(ClaimTypes.Email).Value);
                if (check == "1")
                    Successful = "تمت الاضافة بنجاح";
                else
                    Falied = check;
            }

            return RedirectToAction("Index", new { Successful = Successful, Falied = Falied });

            //return View(await _domain.GetAllbooking());
        }
        //
        public async Task<IEnumerable<FloorViewsModels>> getFloorByBuildingId(Guid id)
        {

            return await _floorDomain.getFloorByBuildinGuid(id);
        }

    }
}