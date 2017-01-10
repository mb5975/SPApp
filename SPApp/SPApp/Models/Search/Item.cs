using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPApp.Models.Search
{
    public class Item
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public int RentLength { get; set; }

        public bool IsAvailable { get; set; }
        public string Url { get; set; } //fill in controller with Url.Action

        public Item(Models.item item)
        {
            Code = item.identificationCode;
            Name = item.name;
            RentLength = item.rent_days_length;
            IsAvailable = item.isAvailable;
            //Url in controller
        }
    }
}