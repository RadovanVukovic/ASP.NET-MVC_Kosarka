using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace RVAS_Kosarka.Models
{
    public class BoxScore
    {
        [Key, Column(Order = 0)]
        public int GameId { get; set; }

        [Key, Column(Order = 1)]
        public int PlayerId { get; set; }

        [Range(0, 100)]
        public int Points { get; set; }
        
        [Range(0, 50)]
        public int Assists { get; set; }
        
        [Range(0, 50)]
        public int Rebounds { get; set; }


        public virtual Game Game { get; set; }

        public virtual Player Player { get; set; }

    }
}