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
        public static string LogFilePathAndName = AppDomain.CurrentDomain.BaseDirectory + "/App_Data/logs.txt";
        public static string ErrorFilePathAndName = AppDomain.CurrentDomain.BaseDirectory + "/App_Data/errors.txt";
        public class Registration
        {
            public static string InvalidPassword = "Napačno geslo!";
            public static string InvalidUsername = "Napačno uporabniško ime!";
            public static string Failed = "Registracija je bila neuspešna!";
            public static string Success = "Registracija je bila uspešna!";
            public static string InvalidEmail = "Napačen email!";
            public static string UserExists = "Uporabnik že obstaja!";
        }

        public class Session
        {
            public static string CookieName = "Spapp";
        }

        public const string emailRegexPattern = @"^[\wčćžšđ.]+@(\w)+\.(\w)+$";

    }
}