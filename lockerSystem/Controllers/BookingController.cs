using lockerSystem.Domain;
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
            return View( await _domain.GetAllbooking());
        }



    }
}
