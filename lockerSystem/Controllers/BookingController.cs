﻿using lockerSystem.Domain;
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


        public BookingController(BookingDomain domain, BuildingDomain buildingDomain, FloorDomain floorDomain)
        {
            _domain = domain;
            _buildingDomain = buildingDomain;
            _floorDomain = floorDomain;
        }
        public async Task<IActionResult> Index()//index search
        {
            //var booking = await _buildingDomain.GetAllBuildings();
            ViewBag.Building = new SelectList(await _buildingDomain.GetAllBuildings(), "Guid", "NameAr");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Guid? BuildingGuid, Guid? FloorGuid)
        {
            ViewBag.Building = new SelectList(await _buildingDomain.GetAllBuildings(), "Guid", "NameAr", BuildingGuid);
            //ViewData["locker"];
            return View(await _domain.getLockerwithFilter(BuildingGuid, FloorGuid));
        }

        public async Task<IActionResult> Orders()//index
        {

            return View(await _domain.GetAllbooking());
        }

        public async Task<IActionResult> SubmitOrder()//add
        {

            return View(await _domain.GetAllbooking());
        }
        public async Task<IEnumerable<FloorViewsModels>> getFloorByBuildingId(Guid id)
        {

            return await _floorDomain.getFloorByBuildinGuid(id);
        }
    }
}
    

