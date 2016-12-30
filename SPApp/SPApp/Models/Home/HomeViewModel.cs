using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPApp.Models.Home
{
    public class HomeViewModel
    {
        public string FullName { get; set; }
        public List<Item> Items { get; set; }

        public HomeViewModel()
        {
            Items = new List<Item>();
        }

        public HomeViewModel(string fullName, List<string> codes)
        {
            FullName = fullName;
            Items = new List<Item>();
            codes.ForEach(code =>
            {
                Items.Add(Classes.BLs.HomeBL.GetItem(code));
            });
            //Items = new List<Item>();

        }
    }
}