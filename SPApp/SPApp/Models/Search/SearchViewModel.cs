using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPApp.Models.Search
{
    public class SearchViewModel
    {
        public string FullName { get; set; }
        //itema ni tuki gor, ker pride kot json preko js-ja in se dinamično nafila

        public SearchViewModel(string fullName)
        {
            FullName = fullName;
        }
    }
}