using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EVS370.PropertyHub.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EVS370.PropertyHub.WebUI.Controllers
{
    public class NeighborhoodController : SecureController
    {
        [HttpGet]
        public IActionResult Manage()
        {
            if (!IsAdmin) return Redirect("~/users/login?ctl=neighborhood&act=manage");
            List<NeighborhoodModel> models = new PropertyHubHandler().GetNeighborhoods().ToModelList();
            return View(models);
        }
        [HttpGet]
        public IActionResult Create()
        {
            if (!IsAdmin) return Redirect("~/users/login?ctl=neighborhood&act=manage");
            List<SelectListItem> items = new List<SelectListItem> { new SelectListItem { Text = "- Select City -", Value = "0" } };
            List<City> cities = new LocationsHandler().GetCities(new Country { Id = 1 });
            items.AddRange(new LocationsHandler().GetCities(new Country { Id = 1 }).ToItems());
            ViewData["Cities"] = items;
            return PartialView("~/views/neighborhood/_create.cshtml");
        }
        [HttpPost]
        public IActionResult Create(NeighborhoodModel model)
        {
            if (!IsAdmin) return Redirect("~/users/login?ctl=neighborhood&act=manage");
            Neighborhood entity = model.ToEntity();
            IFormFile file = Request.Form.Files["photo"];
            //if (!string.IsNullOrEmpty(file.FileName) && file.Length > 0)
            if (file != null) 
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    entity.Image = ms.ToArray();
                }
            }
            new PropertyHubHandler().AddNeighborhood(entity);
            return RedirectToAction("manage");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!IsAdmin) return Redirect("~/users/login?ctl=neighborhood&act=manage");
            NeighborhoodModel model = new PropertyHubHandler().GetNeighborhood(id).ToModel();
            List<SelectListItem> items = new LocationsHandler().GetCities(new Country { Id = 1 }).ToItems();
            items.Find(x => Convert.ToInt32(x.Value) == model.City.Id).Selected = true;            
            ViewData["Cities"] = items;
            return PartialView("~/views/neighborhood/_edit.cshtml",model);
        }
        [HttpPost]
        public IActionResult Edit(NeighborhoodModel model)
        {
            if (!IsAdmin) return Redirect("~/users/login?ctl=neighborhood&act=manage");
            Neighborhood entity = model.ToEntity();
            IFormFile file = Request.Form.Files["photo"];
            if (!string.IsNullOrEmpty(file.FileName) && file.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    entity.Image = ms.ToArray();
                }
            }
            new PropertyHubHandler().UpdateNeighborhood(model.Id, entity);
            return RedirectToAction("manage");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (!IsAdmin) return Redirect("~/users/login?ctl=neighborhood&act=manage");
            NeighborhoodModel model = new PropertyHubHandler().GetNeighborhood(id).ToModel();            
            return PartialView("~/views/neighborhood/_delete.cshtml", model);
        }
        [HttpPost]
        public IActionResult Delete(NeighborhoodModel model)
        {
            //string temp =Request.Form["Id"]

            if (!IsAdmin) return Redirect("~/users/login?ctl=neighborhood&act=manage");
            new PropertyHubHandler().DeleteNeighborhood(model.Id);
            return RedirectToAction("manage");
        }
    }
}