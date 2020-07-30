using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVS370.PropertyHub
{
    public class PropertyArea 
    {
        public int Id { get; set; }

        public float Value { get; set; }

        public int AdvId { get; set; }

        [Required]
        public virtual PropertyAreaUnit PropertyAreaUnit { get; set; }

    }
}
