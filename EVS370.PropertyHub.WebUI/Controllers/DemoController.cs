using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVS370.PropertyHub.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EVS370.PropertyHub.WebUI.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index(string id)
        {
            //ViewResult
            //PartialViewResult

            //ViewResult v = new ViewResult();
            //v.ViewName = "~/Views/Demo/index.cshtml";
            //return v;

            //ViewBag.Message = "asdasdasd";

            DemoIndexModel m = new DemoIndexModel();
            m.ProductName = "Aaaa";
            m.ProductPrice = 1000;
            m.ProductSuppliers.Add("ali");
            m.ProductSuppliers.Add("qamar");
            m.ProductSuppliers.Add("sohaib");
            m.ProductSuppliers.Add("sadia");
            m.ProductSuppliers.Add("moeed");
            
            ViewData["Message"] = "Welcome " + ((string.IsNullOrWhiteSpace(id)) ? "guest" : id);
            
            return View(m);
        }
    }
}