using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPApp.Models.Index
{
    public class IndexViewModel
    {
        public List<Item> Items { get; set; }

        public IndexViewModel()
        {
            Items = new List<Item>();
        }

        public IndexViewModel(List<string> codes)
        {
            Items = new List<Item>();
            codes.ForEach(code =>
            {
                Items.Add(Classes.BLs.IndexBL.GetItem(code));
            });
        }
    }
}