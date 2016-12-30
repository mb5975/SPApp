using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPApp.Classes.BLs
{
    public class RegistrationBL
    {
        public static bool RegisterUser(Models.Registration.RegistrationViewModel model)
        {
            //TODO preverjanje če že obstaja email tudi oz username
            using (var context = new Models.databaseEntities())
            {
                try
                {
                    bool userExists = context.user_account.Where(u => u.email == model.Email || u.username == model.Username).Any();
                    if (userExists) return false;
                    //validate user
                    //check passwords
                    //check email address with regex

                    //save user
                    Models.user_account user =
                        new Models.user_account(model.Username, model.Email, model.FirstName,
                                                model.LastName, model.Password);
                    context.user_account.Add(user);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

    }
}