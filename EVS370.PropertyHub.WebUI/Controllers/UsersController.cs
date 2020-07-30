using EVS370;
using EVS370.PropertyHub.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EVS370.PropertyHub.WebUI.Common;
using System;
using EVS370.UsersMgt;

namespace EVS_IMPASS.WebUI.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.ReturnUrl = "ctl=" + Request.Query["ctl"] + "&act=" + Request.Query["act"];
            string cookie = Request.Cookies[WebUtil.USER_COOKIE];
            if (!string.IsNullOrWhiteSpace(cookie))
            {
                string[] userData = cookie.Split(",");
                UserModel userModel = new UsersHandler().GetUser(userData[0], userData[1]).ToModel();
                if (userModel != null)
                {
                    Response.Cookies.Append(
                       key: WebUtil.USER_COOKIE,
                       value: $"{userData[0]},{userData[1]}",
                       options: new CookieOptions { Expires = DateTime.Today.AddDays(7), IsEssential = true }
                    );
                    HttpContext.Session.Set(WebUtil.CURRENT_USER, userModel);
                    if (userModel.Role.Id == WebUtil.ADMIN_ROLE) // user is in admin role
                    {
                        return RedirectToAction("admin", "home");
                    }
                    else
                    {
                        return RedirectToAction("index", "home");
                    }
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserModel model)
        {
            UserModel userModel = new UsersHandler().GetUser(model.LoginId, model.Password).ToModel();
            if (userModel != null)
            {
                HttpContext.Session.Set(WebUtil.CURRENT_USER, userModel);
                var remember = Request.Form["rememberme"];
                if (!string.IsNullOrWhiteSpace(remember))
                {
                    Response.Cookies.Append(
                        key: WebUtil.USER_COOKIE,
                        value: $"{model.LoginId},{model.Password}",
                        options: new CookieOptions { Expires = DateTime.Today.AddDays(7), IsEssential = true }
                    );
                }
                string ctl = HttpContext.Request.Query["ctl"];
                string act = HttpContext.Request.Query["act"];
                if (!string.IsNullOrWhiteSpace(ctl) && !string.IsNullOrWhiteSpace(act))
                {
                    return RedirectToAction(act, ctl);
                }
                if (userModel.Role.Id == WebUtil.ADMIN_ROLE) // user is in admin role
                {
                    return RedirectToAction("admin", "home");
                }
                else
                {
                    return RedirectToAction("index", "home");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            //HttpContext.Items.Add("AAA","any object");
            //HttpContext.Items.Remove("AAA");
            //HttpContext.Items["AAA"]

            HttpContext.Response.Cookies.Delete(WebUtil.USER_COOKIE);
            HttpContext.Session.Clear();
            return RedirectToAction("login");
            //string cookie = Request.Cookies[WebUtil.USER_COOKIE];
            //if (cookie != null)
            //{
            //    Response.Cookies.Delete(WebUtil.USER_COOKIE)
            //}
        }
        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(SignupModel model)
        {
            User entity = model.ToEntity();
            new UsersHandler().signup(entity);
            return RedirectToAction("login");
        }
    }
}