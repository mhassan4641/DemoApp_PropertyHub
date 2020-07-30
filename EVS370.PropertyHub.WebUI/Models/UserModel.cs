using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVS370.PropertyHub.WebUI.Models
{
    public class UserModel 
    {
        public int Id { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Image { get; set; } //Base64String
        public Nullable<DateTime> BirthDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        public string ApiKey { get; set; }
        public virtual RoleModel Role { get; set; }
        public virtual AddressModel Address { get; set; }
    }
}

