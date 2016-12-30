using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPApp.Models.Registration
{
    public class RegistrationViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; } //poglej če bo mapper delu za _ v veliko začetnico
        public string LastName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string ErrorMsg { get; set; }

    }
}