using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RVAS_Kosarka.Models
{
    public class Manager
    {
        [ForeignKey("Club")]
        [Display(Name = "Club")]
        public int Id { get; set; }

        [Required]
        [StringLength(70)]
        public string Name { get; set; }

        [Range(0, 100)]
        public int Years { get; set; }

        public virtual Club Club { get; set; }

    }
}