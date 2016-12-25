using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPApp.Models.Recommend
{
    public class RecommendViewModel
    {
        public string FullName { get; set; }

        public RecommendViewModel(string fullName)
        {
            FullName = fullName;
        }
    }
}