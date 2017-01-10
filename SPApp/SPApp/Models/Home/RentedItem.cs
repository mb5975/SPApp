using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPApp.Models.Home
{
    public class RentedItem
    {
        public string IdentificationCode { get; set; }
        public string Name { get; set; }
        public DateTime RentedUntil { get; set; }
        public bool IsReserved { get; set; }
        public string Username { get; set; }

        public RentedItem(Models.item item) //RENTE MORM INCLUDAT!!!
        {
            IdentificationCode = item.identificationCode;
            Name = item.name;
            RentedUntil = item.rent.Where(r => r.isActive == true).Single().rent_end;
            IsReserved = item.isReserved;
            Username = item.rent.Where(r => r.isActive).Select(r => r.user_account.username).Single();
        }
    }
}