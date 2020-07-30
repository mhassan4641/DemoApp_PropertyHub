using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EVS370;
using EVS370.PropertyHub.WebUI.Models;

namespace EVS370.PropertyHub.WebUI.Controllers
{
    public class CountryController : Controller
    {
        public IActionResult Manage()
        {
            List<EVS370.PropertyHub.WebUI.Models.CountryModel> model = new EVS370.LocationsHandler().GetCountries().ToModelList();
            return View(model);
        }
        [HttpGet]
        public IActionResult create()
        {
            return PartialView("~/Views/Country/_create.cshtml");
        }
        [HttpPost]
        public IActionResult create(CountryModel model)
        {
            Country entity = model.ToEntity();
            new LocationsHandler().AddCountry(entity);
            return RedirectToAction("Manage");
        }
        [HttpGet]
        public IActionResult edit(int id)
        {
            CountryModel model = new LocationsHandler().GetCountry(id).ToModel();
            List<SelectListItem> temp = new LocationsHandler().GetCountries().ToSelectListItems();
            temp.Find(x => Convert.ToInt32(x.Value) == model.Id).Selected = true;
            ViewData["countries"] = temp;
            return PartialView("~/Views/Country/_edit.cshtml", model);
        }
        [HttpPost]
        public IActionResult edit(CountryModel model)
        {
            new LocationsHandler().UpdateCountry(model.Id, model.ToEntity());
            return RedirectToAction("Manage");
        }
        [HttpGet]
        public IActionResult delete(int id)
        {
            CountryModel model = new LocationsHandler().GetCountry(id).ToModel();
            return PartialView("~/Views/Country/_delete.cshtml",model);
        }
        [HttpPost]
        public IActionResult delete(CountryModel model)
        {
            new LocationsHandler().DeleteCountry(model.Id);
            return RedirectToAction("Manage");
        }
    }
}