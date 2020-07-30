using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVS370.PropertyHub.WebUI.Models
{
    public class PropertyAreaModel
    {
        public int Id { get; set; }

        public float value { get; set; }

        public PropertyAreaUnitModel Unit { get; set; }
    }
}
