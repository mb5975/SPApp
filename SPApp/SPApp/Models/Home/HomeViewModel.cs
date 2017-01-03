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

        public List<RentedItem> RentedItems { get; set; }

        public HomeViewModel()
        {
            Items = new List<Item>();
            RentedItems = new List<RentedItem>();
        }

        public HomeViewModel(string fullName, string username, List<string> codes)
        {
            FullName = fullName;
            Items = new List<Item>();
            codes.ForEach(code =>
            {
                Items.Add(Classes.BLs.HomeBL.GetItem(code));
            });
            RentedItems = Classes.BLs.HomeBL.GetRentedItems(username);

        }
    }
}