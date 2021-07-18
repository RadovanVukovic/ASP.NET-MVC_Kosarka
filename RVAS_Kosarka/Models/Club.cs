using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RVAS_Kosarka.Models
{
    public class Club
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Range(1800, 2021)]
        public int Founded { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        public virtual Manager Manager { get; set; }

    }
}