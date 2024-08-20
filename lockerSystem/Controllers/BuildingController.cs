using lockerSystem.Domain;
using lockerSystem.Models;
using lockerSystem.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

//sha
namespace lockerSystem.Controllers
{
    public class BuildingController : Controller
    {
        private readonly BuildingDomain _BuildingDomain;
        public BuildingController(BuildingDomain BuildingDomain)
        {

            _BuildingDomain = BuildingDomain;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _BuildingDomain.GetAllBuildings());
        }
        [HttpGet]
        public IActionResult add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult add(BuildingViewsModels Building)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    string check = _BuildingDomain.addBuilding(Building);
                    //ViewData["Successful"] = "تمت الإضافة بنجاح";


                    if (check == "1")
                    {
                        ViewData["Successful"] = "تمت الإضافة بنجاح";

                        return View(Building);
                    }
                    else if (check == "-1")
                    {
                        ViewData["Falied"] = "حدث خطأ أثناء معالجتك طلبك الرجاء المحاولة في وقت لاحق";
                    }
                    else {
                        ViewData["Falied"] = "هذا الرمز يخص مبنى اخر";

                    }

                }

               
            }
            catch
            {
                ViewData["Falied"] = "حدث خطأ أثناء معالجتك طلبك الرجاء المحاولة في وقت لاحق";
            }
            return View(Building);


          
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            return View(_BuildingDomain.getBuildingById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BuildingViewsModels Building)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //_BuildingDomain.editBuilding(Building);

                    string check = _BuildingDomain.editBuilding(Building);

                    if (check == "1")

                    {
                        ViewData["Successful"] = "تم التعديل بنجاح";
                        return View(Building);
                    }


                    else
                        ViewData["Falied"] = check;


                }
                
            }

            catch (Exception ex) {
                ViewData["Falied"] = "حدث خطأ أثناء معالجتك طلبك الرجاء المحاولة في وقت لاحق";
            }
            return View(Building);
        }
       
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
          string check = _BuildingDomain.DeleteBuilding(id);

            if (check == "1")
                ViewData["Successful"] = "تم الحذف بنجاح";
            else
                ViewData["Falied"] = check;
            _BuildingDomain.DeleteBuilding(id);
            return View();
        }

    }
   
}
