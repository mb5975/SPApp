using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPApp.Models.Search
{
    public class SearchViewModel
    {
        public string FullName { get; set; }

        public SearchViewModel(string fullName)
        {
            FullName = fullName;
        }
    }
}