using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPApp.Models.Home
{
    public class Item
    {
        public string IdentificationCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }

        public Item()
        {
            //Empty constructor
        }

        public Item(Models.item item)
        {
            IdentificationCode = item.identificationCode;
            Name = item.name;
            Description = item.description;
            Author = item.author;
        }
    }
}