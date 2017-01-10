using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPApp.Models.AddItem
{
    public class Item
    {
        public string IdentificationCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Year { get; set; }
        public bool IsAvailable { get; set; }
        public string Author { get; set; }
        public List<Link> Links { get; set; }
        public int RentLengthDays { get; set; }

        public Item()
        {
            //Empty constructor
            Links = new List<Link>();
        }

        //public Item(string code, string name, string description, string type, int year, string author, List<Link> links)
        //{
        //    IdentificationCode = code;
        //    Name = name;
        //    Description = description;
        //    Type = type;
        //    Year = year;
        //    IsAvailable = true; //default, when creating new item
        //    Author = author;
        //    Links = links;
        //    RentLengthDays = 
        //}
    }
}