using EVS370.UsersMgt;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVS370.PropertyHub.WebUI.Models
{
    public class AddressModel
    {
        public int Id { get; set; }
        
        public string StreetAddress { get; set; }

        public virtual CityModel City { get; set; }


    }
}
