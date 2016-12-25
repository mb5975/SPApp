using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPApp.Models.Statistics
{
    public class StatisticsViewModel
    {
        public string FullName { get; set; }

        public StatisticsViewModel(string fullName)
        {
            FullName = fullName;
        }
    }
}