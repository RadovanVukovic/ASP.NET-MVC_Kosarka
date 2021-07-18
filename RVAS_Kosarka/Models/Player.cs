using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RVAS_Kosarka.Models
{
    public class Player
    {
        public int Id { get; set; }

        [Required]
        [StringLength(70)]
        public string Name { get; set; }

        [Display(Name = "Height (cm)")]
        [Range(130, 250)]
        public int Height { get; set; }

        [Display(Name = "Weight (kg)")]
        [Range(30, 200)]
        public int Weight { get; set; }

        [Range(0, 100)]
        public int Years { get; set; }

        [Display(Name = "Position")]
        public int PositionId { get; set; }

        [Display(Name = "Club")]
        public int ClubId { get; set; }

        
        public Position Position { get; set; }
        
        public Club Club { get; set; }

        public virtual ICollection<BoxScore> BoxScores { get; set; }

    }
}