using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVS370.PropertyHub.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EVS370.PropertyHub.WebUI.Controllers
{
    public class LocationsController : Controller
    {
        //get dropdownlist for cities  based on country id
        public IActionResult CitiesDDL(int id)
        {
            DDListModel m = new DDListModel { Name = "citiesddl", Caption = "- City -", Icon = "fa-map-marker" };
            m.Items = new List<SelectListItem> { new SelectListItem { Value = "0", Text = "- City -" } };
            m.Items.AddRange(new LocationsHandler().GetCities(new Country { Id = id }).ToItems());
            return PartialView("~/views/shared/_ddlist.cshtml", m);
        }

        //get dropdownlist for neighborhood areas based on city id
        public IActionResult NeighborhoodsDDL(int id)
        {
            DDListModel m = new DDListModel { Name = "neighborhoodsddl", Icon = "fa-map-marker" };
            m.Items = new List<SelectListItem> { new SelectListItem { Value="0", Text= "- Neighborhood Area -" } };
            m.Items.AddRange(new  PropertyHubHandler().GetNeighborhoods(new City { Id=id }).ToItems());
            return PartialView("~/views/shared/_ddlist.cshtml", m);
        }
    }
}