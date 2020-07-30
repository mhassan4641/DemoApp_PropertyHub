using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVS370.PropertyHub.WebUI.Models
{
    public class DDListModel
    {
        public string Caption { get; set; }

        public string Name { get; set; }

        public string Icon { get; set; }

        public List<SelectListItem> Items { get; set; }


    }
}
