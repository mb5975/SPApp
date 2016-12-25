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
    }
}