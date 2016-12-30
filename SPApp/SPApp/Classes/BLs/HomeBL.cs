using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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