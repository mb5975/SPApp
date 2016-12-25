using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPApp.Models.Login
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ErrorMsg { get; set; }
        public string SuccessMsg { get; set; }
    }
}