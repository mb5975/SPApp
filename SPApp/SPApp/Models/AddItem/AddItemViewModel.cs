using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPApp.Models.AddItem
{
    public class AddItemViewModel
    {
        public string FullName { get; set; }
        public Item Item { get; set; }

        public AddItemViewModel()
        {
            //Empty constructor
        }

        public AddItemViewModel(string fullName)
        {
            FullName = fullName;
            Item = new Item();
        }
    }
}