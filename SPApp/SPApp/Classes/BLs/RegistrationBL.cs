using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SPApp.Classes.BLs
{
    public class RegistrationBL
    {
        public enum RegistrationStatus
        {
            UserExists,
            InvalidPassword,
            InvalidEmail,
            Success
        }
        public static RegistrationStatus RegisterUser(Models.Registration.RegistrationViewModel model)
        {
            //TODO preverjanje če že obstaja email tudi oz username
            using (var context = new Models.databaseEntities())
            {
                try
                {
                    bool userExists = context.user_account.Where(u => u.email == model.Email || u.username == model.Username).Any();
                    if (userExists) return RegistrationStatus.UserExists;
                    //validate user
                    //check passwords
                    if (model.Password != model.ConfirmPassword || model.Password.Length < 8)
                    {
                        return RegistrationStatus.InvalidPassword;
                    }
                    //check email address with regex
                    Regex r = new Regex(Consts.emailRegexPattern, RegexOptions.IgnoreCase);
                    Match m = r.Match(model.Email);
                    if (!m.Success) {
                        return RegistrationStatus.InvalidEmail;
                    }

                    //save user
                    Models.user_account user =
                        new Models.user_account(model.Username, model.Email, model.FirstName,
                                                model.LastName, model.Password);
                    context.user_account.Add(user);
                    context.SaveChanges();
                    //LOGIRAJ USPEŠNO REGISTRACIJO
                    Common.CommonBL.Log("Registracija uspela za uporabniško ime: " + model.Username);
                    return RegistrationStatus.Success;
                }
                catch (Exception ex)
                {
                    Common.CommonBL.LogError(ex.Message + " " + ex.InnerException);
                    throw ex;
                }
            }
        }

    }
}