using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVS370.PropertyHub.WebUI.Models
{
    public class DemoIndexModel
    {
        public DemoIndexModel()
        {
            ProductSuppliers = new List<string>();
        }

        public string ProductName { get; set; }

        public int ProductPrice { get; set; }

        public List<string> ProductSuppliers { get; set; }

    }
}
