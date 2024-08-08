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
        public BookingController(BookingDomain domain)
        {
            _domain = domain;
        }

        public async Task<IActionResult> Index()
        {
            
            return View(await _domain.GetAllbooking());
        }

        [HttpGet]
        public IActionResult add()
        {
            /*ViewBag.book = new SelectList(_domain.getIdBook(), "Id" , "NameAr");*/// كيف بيجيبه وهو ماله ارتباط مباشر مع جدول البيلدينق؟؟
            return View();
        }

        [HttpPost]
        public IActionResult add(BookingViewsModels book)
        {
            //ViewBag.book = new SelectList(_domain.getIdBook(), "Id", "NameAr");
            return View();
        }


    }
}
