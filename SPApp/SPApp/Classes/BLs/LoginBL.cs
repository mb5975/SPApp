using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPApp.Classes.BLs
{
    public class LoginBL
    {
        public enum LoginStatus
        {
            InvalidUsername,
            InvalidPassword,
            Success
        }

        public static LoginStatus LoginUser(Models.Login.LoginViewModel model)
        {
            //TODO preverjanje če že obstaja email tudi oz username
            using (var context = new Models.databaseEntities())
            {
                try
                {
                    var user = context.user_account.Where(u => u.username == model.Username).FirstOrDefault();
                    if (user == null) { //poglej če je to default value!!!
                        return LoginStatus.InvalidUsername;
                    }
                    //validate password
                    if (model.Password != user.password)
                    {
                        return LoginStatus.InvalidPassword;
                    }

                    return LoginStatus.Success;                    
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