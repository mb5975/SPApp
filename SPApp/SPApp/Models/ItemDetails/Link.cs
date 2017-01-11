using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPApp.Models.ItemDetails
{
    public class Link
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link1 { get; set; }

        public Link()
        {
            //Empty constructor
        }

        public Link(Models.link link)
        {
            Id = link.link_id;
            Name = link.name;
            Link1 = link.link1;
        }
    }
}