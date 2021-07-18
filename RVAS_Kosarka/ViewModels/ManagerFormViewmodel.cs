using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RVAS_Kosarka.Models;


namespace RVAS_Kosarka.ViewModels
{
    public class ManagerFormViewmodel
    {
        public IEnumerable<Club> Clubs { get; set; }

        public Manager Manager { get; set; }

    }
}