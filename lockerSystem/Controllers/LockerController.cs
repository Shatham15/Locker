using Microsoft.AspNetCore.Mvc;

namespace lockerSystem.Controllers
{
    public class LockerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
