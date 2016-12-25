using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPApp.Models.ItemDetails
{
    public class ItemDetailsViewModel
    {
        public string FullName { get; set; }

        public ItemDetailsViewModel(string fullName)
        {
            FullName = fullName;
        }
    }

}