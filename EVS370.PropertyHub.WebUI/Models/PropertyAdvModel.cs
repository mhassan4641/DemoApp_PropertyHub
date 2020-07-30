using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVS370.PropertyHub.WebUI.Models
{
    public class PropertyAdvModel
    {
        public PropertyAdvModel()
        {
            Images = new List<string>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

        public string Description { get; set; }

        public DateTime PostedOn { get; set; }

        public DateTime ActiveTill { get; set; }
        public List<string> Images { get; set; }
        public UserModel PostedBy  { get; set; }

        public AdvStatusModel Status { get; set; }
        public AdvTypeModel AdvType { get; set; }
        public PropertyAreaModel Area { get; set; }
        public NeighborhoodModel Neighborhood { get; set; }

    }
}
