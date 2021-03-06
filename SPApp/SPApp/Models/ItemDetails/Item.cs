﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPApp.Models.ItemDetails
{
    public class Item
    {
        //public int Id { get; set; }
        public string IdentificationCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Year { get; set; }
        public bool IsAvailable { get; set; }
        public string Author { get; set; }
        public List<Link> Links { get; set; }

        public Item()
        {
            //Empty constructor
            Links = new List<Link>();
        }

        public Item(Models.item item)
        {
            //Id = item.item_id;
            IdentificationCode = item.identificationCode;
            Name = item.name;
            Description = item.description;
            Type = item.type;
            Year = item.year;
            IsAvailable = item.isAvailable; //default, when creating new item
            Author = item.author;
            //LINKS
            List<Link> links = new List<Link>();
            foreach(var link in item.link)
            {
                links.Add(new Link(link));
            }
            Links = links;
        }

    }
}