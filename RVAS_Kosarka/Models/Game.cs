using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RVAS_Kosarka.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Range(0, 200)]
        public int HomePoints { get; set; }

        [Range(0, 200)]
        public int AwayPoints { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [StringLength(50)]
        public string Stadium { get; set; }

        [Required]
        [StringLength(50)]
        public string  City { get; set; }


        public virtual ICollection<BoxScore> BoxScores { get; set; }
    }
}