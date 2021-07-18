using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RVAS_Kosarka.Models;

namespace RVAS_Kosarka.ViewModels
{
    public class PlayerFormViewModel
    {
        public IEnumerable<Position> Positions { get; set; }
        public IEnumerable<Club> Clubs { get; set; }
        public Player Player { get; set; }

    }
}