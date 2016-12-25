using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPApp.Models.Home
{
    public class HomeViewModel
    {
        public string FullName { get; set; }

        public HomeViewModel(string fullName)
        {
            FullName = fullName;
        }
    }
}