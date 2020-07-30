using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EVS370.PropertyHub.WebUI.Common;
using EVS370.PropertyHub.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EVS370.PropertyHub.WebUI.Controllers
{
    public class AdvertizementsController : SecureController
    {
        [HttpGet]
        public IActionResult Manage()
        {
            if (!IsAdmin) 
                Redirect("users/login?ctl=advertizements&act=manage");
            ViewData["TopAdvs"] = new PropertyHubHandler().GetPendingAdvertizements().ToModelList();
            if (!IsLogin)
            {
                return RedirectToAction("login", "users");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Post()
        {
            if (!IsAdmin) Redirect("users/login?ctl=advertizements&act=manage");
            List<SelectListItem> countries = new List<SelectListItem> { new SelectListItem { Text="- Country -", Value="0" } };
            countries.AddRange(new LocationsHandler().GetCountries().ToItems());
            ViewData["Countries"] = countries;

            List<SelectListItem> areaUnits = new List<SelectListItem> { new SelectListItem { Text = "- Area Unit -", Value = "0" } };
            areaUnits.AddRange(new PropertyHubHandler().GetPropertyAreaUnits().ToItems());
            ViewData["AreaUnits"] = areaUnits;

            List<SelectListItem> advTypes = new PropertyHubHandler().GetAdvsTypes().ToItems();
            ViewData["AdvTypes"] = advTypes;

            return PartialView("~/views/advertizements/_Post.cshtml");
        }


        [HttpPost]
        public IActionResult Post(PropertyAdvModel model)
        {

            model.Neighborhood = new NeighborhoodModel { Id = Convert.ToInt32(Request.Form["neighborhoodsddl"]) };
            model.AdvType = new AdvTypeModel { Id = Convert.ToInt32(Request.Form["advtype"]) };

            model.PostedBy = new UserModel { Id =(HttpContext.Session.Get<UserModel>(WebUtil.CURRENT_USER).Id)  }; // this will currently login user
            model.PostedOn = DateTime.Now; //current date time
            model.Status = new AdvStatusModel { Id = 1 }; //pending

            PropertyAdv entity = model.ToEntity();
            //images
            if (Request.Form.Files != null && Request.Form.Files.Count > 0)
            {
                string[] phcaptions = Request.Form["phcaption"].ToArray();
                for (int i = 0; i < Request.Form.Files.Count; i++)
                {
                    IFormFile file = Request.Form.Files[i];
                    if (!string.IsNullOrWhiteSpace(file.FileName) && file.Length != 0)
                    {
                        AdvImage advImage = new AdvImage();
                        advImage.DisplayRank = i + 1;
                        advImage.Caption = phcaptions[i];
                        using (MemoryStream ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            advImage.Content = ms.ToArray();
                        }
                        entity.Images.Add(advImage);
                    }
                }
            }
            new PropertyHubHandler().AddAdvertizement(entity);
            return RedirectToAction("index", "home");
        }

        public IActionResult Details(int id)
        {
            PropertyAdvModel m = new PropertyHubHandler().GetAdvertizement(id).ToModel();
            return PartialView("~/views/advertizements/_details.cshtml", m);
        }
        public IActionResult AcceptAdv(int id)
        {
            PropertyAdv entity = new PropertyHubHandler().GetAdvertizement(id);
            entity.Status.Id = 2;
            new PropertyHubHandler().AcceptAdv(entity);
            return PartialView("~/views/advertizements/_accept.cshtml");
        }
        public IActionResult RejectAdv(int id)
        {
            PropertyAdv entity = new PropertyHubHandler().GetAdvertizement(id);
            entity.Status = new AdvStatus { Id = 3 };
            new PropertyHubHandler().RejectAdv(entity);
            return PartialView("~/views/advertizements/_reject.cshtml");
        }


    }
}