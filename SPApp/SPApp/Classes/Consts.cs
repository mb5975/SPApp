using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPApp.Classes
{
    public class Consts
    {

        public static string DbAdminString = "admin";
        //public static int DefaultIntValue = -1;

        public class Registration
        {
            public static string InvalidPassword = "Napačno geslo";
            public static string InvalidUsername = "Napačno uporabniško ime";
            public static string Failed = "Registracija je bila neuspešna!";
            public static string Success = "Registracija je bila uspešna!";
        }

        public class Session
        {
            public static string CookieName = "Spapp";
        }


    }
}