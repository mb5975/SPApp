using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SPApp.Classes.BLs
{
    public class IndexBL
    {
        public static Models.Index.Item GetItem(string code)
        {
            //TODO preverjanje če že obstaja email tudi oz username
            using (var context = new Models.databaseEntities())
            {
                try
                {
                    var item = context.item
                                      //.Include(i => i.rent)
                                      .Where(i => i.identificationCode == code)
                                      .FirstOrDefault();
                    if (item == null)
                    {
                        return null;
                    }
                    return new Models.Index.Item(item);
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