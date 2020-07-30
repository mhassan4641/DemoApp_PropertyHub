using EVS370.UsersMgt;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVS370.PropertyHub
{
    public class PropertyAdv : IListable
    {
        public PropertyAdv()
        {
            Images = new List<AdvImage>();
        }

        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }

        public float Price { get; set; }

        [Column(TypeName = "varchar(MAX)")]
        public string Description { get; set; }

        public DateTime PostedOn { get; set; }
        
        public DateTime ActiveTill { get; set; }

        [Required]
        public virtual AdvType Type { get; set; }

        [Required]
        public virtual AdvStatus Status { get; set; }
        
        public virtual User PostedBy { get; set; }

        public virtual ICollection<AdvImage> Images { get; set; }

        [Required]
        public virtual PropertyArea Area { get; set; }

        [Required]
        public virtual Neighborhood Neighborhood { get; set; }



    }
}
