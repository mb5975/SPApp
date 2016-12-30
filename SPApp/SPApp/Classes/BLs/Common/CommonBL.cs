using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPApp.Classes.BLs.Common
{
    public class CommonBL
    {
        public static string GetUserFullNameFromUsername(string username)
        {
            //TODO preverjanje če že obstaja email tudi oz username
            using (var context = new Models.databaseEntities())
            {
                try
                {
                    var user = context.user_account.Where(u => u.username == username).FirstOrDefault();
                    if (user == null)
                    { //poglej če je to default value!!!
                        return null;
                    }
                    return user.first_name + " " + user.last_name;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
            }
        }

        public static bool IsUserAdmin(string username)
        {
            using (var context = new Models.databaseEntities())
            {
                try
                {
                    var user = context.user_account.Where(u => u.username == username).FirstOrDefault();
                    if (user.user_type == Consts.DbAdminString)
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
            }
        }



        public static Models.ItemDetails.Item GetItem(string code)
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
                    return new Models.ItemDetails.Item(item);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
            }
        }

        public static bool SaveItem(Models.AddItem.Item model)
        {
            using (var context = new Models.databaseEntities())
            {
                try
                {
                    var exists = context.item.Where(i => i.identificationCode == model.IdentificationCode).Any();
                    if (exists)
                    {
                        return false;
                    }
                    Models.item item = new Models.item();
                    item.author = model.Author;
                    item.description = model.Description;
                    item.identificationCode = model.IdentificationCode;
                    item.isAvailable = true; //TODO
                    //item.item_image //TODO
                    model.Links.ForEach(link => {
                        var linkTmp = new Models.link();//to ni v konstruktorju, ker je auto generated
                        linkTmp.link1 = link.Link1;
                        linkTmp.name = link.Name;
                        item.link.Add(linkTmp);
                    });
                    item.name = model.Name;
                    item.type = model.Type;
                    item.year = model.Year;
                    context.item.Add(item);
                    context.SaveChanges();
                    return true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
            }

        }
        //VALIDATE BEFORE SAVING IN DIFFERENT METHOD
        public static bool UpdateItem(Models.ItemDetails.Item model)
        {
            using (var context = new Models.databaseEntities())
            {
                try
                {
                    Models.item item = context.item.Where(i => i.identificationCode == model.IdentificationCode).Single();
                    item.author = model.Author;
                    item.description = model.Description;
                    item.identificationCode = model.IdentificationCode;
                    item.isAvailable = true; //TODO
                    //item.item_image //TODO
                    foreach(var link in model.Links)
                    {
                        //TODO brisanje
                        if (item.link.Where(l => l.name == link.Name && l.link1 == link.Link1).Any()) continue; //skip 
                        var linkTmp = new Models.link();//to ni v konstruktorju, ker je auto generated
                        linkTmp.link1 = link.Link1;
                        linkTmp.name = link.Name;
                        linkTmp.item_id = context.item.Where(i => i.identificationCode == model.IdentificationCode).Select(i => i.item_id).Single();
                        context.link.Add(linkTmp); //new link
                        item.link.Add(linkTmp);
                    }
                    item.name = model.Name;
                    item.type = model.Type;
                    item.year = model.Year;
                    context.SaveChanges();
                    return true;

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