using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVS370.PropertyHub.WebUI.Common;
using EVS370.PropertyHub.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EVS370.PropertyHub.WebUI.Controllers
{
    public class SecureController : Controller
    {

        public bool IsLogin
        {
            get
            {
                UserModel currentUser = HttpContext.Session.Get<UserModel>(WebUtil.CURRENT_USER);
                return currentUser != null;
            }
        }


        public bool IsAdmin
        {
            get
            {
                UserModel currentUser = HttpContext.Session.Get<UserModel>(WebUtil.CURRENT_USER);
                return currentUser != null && currentUser.Role.Id == WebUtil.ADMIN_ROLE;
            }
        }
    }
}