using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPApp.Models.ItemDetails
{
    public class Rent
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }


        public Rent()
        {

        }

        public Rent(Models.rent rent)
        {
            Start = rent.rent_start;
            End = rent.rent_end;
        }

    }

    
}