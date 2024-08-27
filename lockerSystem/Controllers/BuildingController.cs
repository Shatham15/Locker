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
        {//kjj

            _BuildingDomain = BuildingDomain;
        }
        public async Task<IActionResult> Index(string seaechString)
        {
            var building = await _BuildingDomain.GetAllBuildings();
            if (!String.IsNullOrEmpty(seaechString)) {
                building = building.Where(n => n.code.Contains(seaechString)).ToList();
            
            }
            return View(building);

        }
        [HttpGet]
        public async Task<IActionResult> add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> add(BuildingViewsModels Building)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    string check = await _BuildingDomain.addBuilding(Building);
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
                    else if (check == "3")
                    {
                        ViewData["Falied"] = "هذا الرمز يخص مبنى آخر";

                    }
                    else if (check == "4")
                    {
                        ViewData["Falied"] = "رقم المبنى يخص مبنى آخر";

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
        public async Task<IActionResult> Edit(Guid id)
        {
            return View(await _BuildingDomain.getBuildingById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BuildingViewsModels Building)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //_BuildingDomain.editBuilding(Building);

                    string check =await _BuildingDomain.editBuilding(Building);

                    if (check == "1")

                    {
                        ViewData["Successful"] = "تم التعديل بنجاح";
                        return View(Building);
                    }

                    else if (check == "-1")
                    {
                        ViewData["Falied"] = "حدث خطأ أثناء معالجتك طلبك الرجاء المحاولة في وقت لاحق";
                    }
                    else if (check == "3")
                    {
                        ViewData["Falied"] = "هذا الرمز يخص مبنى آخر";

                    }
                    else if (check == "4")
                    {
                        ViewData["Falied"] = "رقم المبنى يخص مبنى آخر";

                    }


                }
                
            }

            catch (Exception ex) {
                ViewData["Falied"] = "حدث خطأ أثناء معالجتك طلبك الرجاء المحاولة في وقت لاحق";
            }
            return View(Building);
        }
       
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                string check = await _BuildingDomain.DeleteBuilding(id);

                if (check == "1")
                    ViewData["Successful"] = "تم الحذف بنجاح";
                else
                    ViewData["Falied"] = check;
                await _BuildingDomain.DeleteBuilding(id);

                return View();
            }

            catch (Exception ex)
            {
                ViewData["Falied"] = "حدث خطأ أثناء معالجتك طلبك الرجاء المحاولة في وقت لاحق";
            }
            return View();

        }

    }
   
}
