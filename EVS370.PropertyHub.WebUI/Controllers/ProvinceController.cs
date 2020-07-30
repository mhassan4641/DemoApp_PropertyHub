using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVS370.PropertyHub.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EVS370.PropertyHub.WebUI.Controllers
{
    public class ProvinceController : Controller
    {
        public IActionResult Manage()
        {
            //List<Province> modelList = new LocationsHandler().GetProvinces(new Country { Id = id });
            //modelList.ToModelList();




            return View();
        }
        public IActionResult GetProvinceById(int id)
        {
            return View();
        }
    }
}