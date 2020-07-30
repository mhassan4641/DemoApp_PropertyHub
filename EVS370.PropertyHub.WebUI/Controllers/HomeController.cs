using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVS370.PropertyHub.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EVS370.PropertyHub.WebUI.Common;

namespace EVS370.PropertyHub.WebUI.Controllers
{
    public class HomeController : SecureController
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["TopAdvs"] = new PropertyHubHandler().GetAcceptedAdvertizements().ToModelList();
            
            return View();
        }

        [HttpGet]
        public IActionResult Admin()
        {
            if (!IsAdmin) return Redirect("~/users/login?ctl=home&act=admin");
            return View();
        }
    }
}