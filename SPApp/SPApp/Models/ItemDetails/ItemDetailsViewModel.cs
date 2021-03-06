﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPApp.Models.ItemDetails
{
    public class ItemDetailsViewModel
    {
        public string FullName { get; set; }

        public Item Item { get; set; }

        public List<Rent> Rents { get; set; }

        //public int IdForRemove { get; set; } //0 by default

        public string ErrorMsg { get; set; }

        public ItemDetailsViewModel()
        {
            Item = new Item();
            Rents = new List<Rent>();
        }

        public ItemDetailsViewModel(string fullName, string code)
        {
            FullName = fullName;
            Item = Classes.BLs.Common.CommonBL.GetItem(code);
            Rents = Classes.BLs.Common.CommonBL.GetRentsForItem(code);
        }
    }

}