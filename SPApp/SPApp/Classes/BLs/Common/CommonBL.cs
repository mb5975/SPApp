using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                    var item = context.item.Where(i => i.identificationCode == code)
                                           .Include(i => i.link)
                                           .FirstOrDefault();
                    if (item == null)
                    { //poglej če je to default value!!!
                        throw new Exception();
                        //return null;
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
                    model.Links.ForEach(link =>
                    {
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
                    //item.isAvailable = true; //TODO ni nujno da je prosto...
                    //item.item_image //TODO
                    List<int> linksToRemove = new List<int>(item.link.Select(l => l.link_id));
                    foreach (var link in model.Links)
                    {
                        //na obeh straneh je link -> ne naredi nič
                        if (link.Id != 0) //po defaultu, če je na novo dodan. če ne ima id iz baze
                        {
                            linksToRemove.Remove(link.Id);
                            continue; //skip 
                        }
                        //link je samo na viewModel -> dodaj
                        else
                        {
                            var linkTmp = new Models.link();//to ni v konstruktorju, ker je auto generated
                            linkTmp.link1 = link.Link1;
                            linkTmp.name = link.Name;
                            linkTmp.item_id = context.item.Where(i => i.identificationCode == model.IdentificationCode).Select(i => i.item_id).Single();
                            context.link.Add(linkTmp); //new link
                            item.link.Add(linkTmp);
                        }

                    }
                    //brisanje
                    foreach (int id in linksToRemove)
                    {
                        context.link.Remove(item.link.Where(l => l.link_id == id).Single());
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


        //public static Models.ItemDetails.Link GetLink(int id)
        //{
        //    //TODO preverjanje če že obstaja email tudi oz username
        //    using (var context = new Models.databaseEntities())
        //    {
        //        try
        //        {
        //            var link = context.link.Where(l => l.link_id == id).Single();
        //            if (link == null)
        //            { //poglej če je to default value!!!
        //                throw new Exception();
        //                //return null;
        //            }
        //            return new Models.ItemDetails.Link(link);
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //            throw ex;
        //        }
        //    }
        //}

        public static bool RemoveLink(Models.ItemDetails.Item item, int id)
        {
            using (var context = new Models.databaseEntities())
            {
                try
                {
                    var success = item.Links.Remove(item.Links.Single(l => l.Id == id));
                    if (!success) return false;
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
            }
        }


        //itemDetails:
        public static void RentItem(string code, string username)
        {
            using (var context = new Models.databaseEntities())
            {
                try
                {
                    //po code najdi item
                    var item = context.item.Where(i => i.identificationCode == code)
                                           //.Include(i => i.link)
                                           .Single();

                     //new Models.ItemDetails.Item(item);
                    //poglej če je res frej in če NI rezerviran
                    if (!item.isAvailable)
                    {
                        throw new Exception("item not available");
                        
                    }
                    //else if (item.isReserved) //TODO poglej če je rezervacija od current user in naredi tabelo rezervacij!! da sploh veš kdo je kaj rezerviral
                    //naredi nov rent
                    Models.rent newRent = new Models.rent();
                    newRent.rent_start = DateTime.Now;
                    newRent.rent_end = DateTime.Now.AddDays(14);//TODO 14 dni zaenkrat
                    var userId = context.user_account.Where(u => u.username == username).Select(u => u.user_account_id).Single();
                    newRent.user_account_id = userId;
                    newRent.isActive = true; //Takoj aktiven?? tudi če ga še ni prevzel??
                    context.rent.Add(newRent);
                    //poveži rent z item-om in user_account-om
                    //dodaj record v rent_item povezovalno tabelo
                    item.rent.Add(newRent);
                    item.isAvailable = false; //po novem ni available
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
            }
        }

        public static List<Models.ItemDetails.Rent> GetRentsForItem(string code)
        {
            using (var context = new Models.databaseEntities())
            {
                try
                {
                    var item = context.item.Where(i => i.identificationCode == code)
                                           .Include(i => i.rent)
                                           .FirstOrDefault();
                    if (item == null)
                    { //poglej če je to default value!!!
                        throw new Exception();
                        //return null;
                    }

                    List<Models.ItemDetails.Rent> result = new List<Models.ItemDetails.Rent>();
                    foreach (var rent in item.rent)
                    {
                        result.Add(new Models.ItemDetails.Rent(rent));
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
            }
        }


        public static void ReturnItem(string code, string username)
        {
            using (var context = new Models.databaseEntities())
            {
                try
                {
                    //po code najdi item
                    var item = context.item.Where(i => i.identificationCode == code)
                                           //.Include(i => i.link)
                                           .Single();

                    //poglej če je res izposojen
                    if (item.isAvailable)
                    {
                        throw new Exception("item available");

                    }
                    //spremeni rentEnd če je treba, ITEM IMA LAHKO SAMO EN AKTIVEN RENT NAENKRAT
                    var activeRent = item.rent.Where(r => r.isActive).Single();
                    activeRent.isActive = false;
                    activeRent.rent_end = DateTime.Now;
                    //item postavi na available
                    item.isAvailable = true;
                    context.SaveChanges();
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