using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVS370.PropertyHub.WebUI.Models
{
    public class SignupModel
    {
        public string fullName { get; set; }
        public string contactNum { get; set; }
        public string password { get; set; }
        public Nullable<DateTime> BirthDate { get; set; }
    }
}
