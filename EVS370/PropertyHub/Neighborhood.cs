using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVS370.PropertyHub
{
    //Neibhourhood Area
    public class Neighborhood : IListable
    {
        public Neighborhood()
        {
        }

        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        public virtual City City { get; set; }

        [Column(TypeName="image")]
        public byte[] Image { get; set; }

    }
}
