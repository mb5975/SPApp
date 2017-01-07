﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace SPApp.Classes.BLs
{
    public class HomeBL
    {
        public static Models.Home.Item GetItem(string code)
        {
            //TODO preverjanje če že obstaja email tudi oz username
            using (var context = new Models.databaseEntities())
            {
                try
                {
                    var item = context.item.Where(i => i.identificationCode == code).FirstOrDefault();
                    if (item == null)
                    { //poglej če je to default value!!!
                        return null;
                    }
                    return new Models.Home.Item(item);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
            }
        }

        public static List<Models.Home.RentedItem> GetRentedItems(string username)
        {
            //TODO preverjanje če že obstaja email tudi oz username
            using (var context = new Models.databaseEntities())
            {
                try
                {
                    var user = context.user_account.Where(u => u.username == username).Single();
                    List<Models.rent> usersActiveRents = user.rent.Where(r => r.isActive).ToList();
                    //en rent ma lahko več itemov, lahko je več rentov aktivnih naenkrat
                    List<Models.Home.RentedItem> rentedItems = new List<Models.Home.RentedItem>();
                    foreach (var rent in usersActiveRents)
                    {
                        foreach (var item in rent.item)
                        {
                            rentedItems.Add(new Models.Home.RentedItem(item));
                        }
                    }
                    //rented items ima vse aktivne iteme, ki si jih je user izposodil
                    return rentedItems;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
            }
        }

        public static List<string> GenerateCodes()
        {
            using (var context = new Models.databaseEntities())
            {
                try
                {
                    var itemList = context.item.Select(i => i.identificationCode).OrderBy(x => Guid.NewGuid()).Take(1).ToList(); //TODO 3
                    return itemList;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
            }
        }
    }
}