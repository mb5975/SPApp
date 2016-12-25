using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPApp.Models.About
{
    public class AboutViewModel
    {
        public string FullName { get; set; }

        public AboutViewModel(string fullName)
        {
            FullName = fullName;
        }
    }
}