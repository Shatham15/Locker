using lockerSystem.Domain;
using lockerSystem.Models;
using lockerSystem.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace lockerSystem.Controllers
{
    public class SemsterController : Controller
    {
        private readonly SemsterDomain _SemsterDomain;
        public SemsterController(SemsterDomain SemsterDomain)
        {

            _SemsterDomain = SemsterDomain;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _SemsterDomain.GetAllSemsters());
        }
        [HttpGet]
        public IActionResult add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult add(SemsterViewsModels Semster)
        {

            if (ModelState.IsValid)
            {
                string check = _SemsterDomain.addSemster(Semster);

                if (check == "1") //Sweet alert

                    ViewData["Successful"] = ".تمت الإضافة بنجاح";
                else
                    ViewData["Falied"] = check;
            }

            return View(Semster);



        }
        [HttpGet]
        public IActionResult Edit(Guid id) //باستخدام GUID وليس ID
        {
            return View(_SemsterDomain.getSemsterById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SemsterViewsModels Semster)
        {


            //_SemsterDomain.editSemster(Semster);
            //return View(Semster);


            if (ModelState.IsValid)
            {
                string check = _SemsterDomain.editSemster(Semster);


                if (check == "1") //Sweet alert

                    ViewData["Successful"] = "تم التعديل بنجاح";



                else
                    ViewData["Falied"] = check;
            }

            return View();


            //return View(Semster);
        }


        //[HttpGet]
        public IActionResult Delete(Guid id)
        {



            string check = _SemsterDomain.DeleteSemster(id);


            if (check == "1") //Sweet alert

                ViewData["Successful"] = "تم الحذف بنجاح";



            else
                ViewData["Falied"] = check;

            _SemsterDomain.DeleteSemster(id);
            return View();
        }







    }

}