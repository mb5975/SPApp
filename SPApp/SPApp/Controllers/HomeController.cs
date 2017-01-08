using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SPApp.Models;

namespace SPApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {   //TODO ALI JE TO PAMETNO?? DA SE NE BO ZACIKLAL
            //var codes = Classes.BLs.HomeBL.GenerateCodes();
            //while (codes == null)
            //{

            //    codes = Classes.BLs.HomeBL.GenerateCodes();
            //}
            Models.Index.IndexViewModel model = new Models.Index.IndexViewModel(Classes.BLs.HomeBL.GenerateCodes());
            return View(model);
        }

        public ActionResult About()
        {
            var valid = IsSessionValid();
            if (!valid)
            {
                //InvalidSessionRedirect();
                ViewBag.IsValidSession = false;
                return View();
            }
            else
            {
                string fullName = GetFullNameFromCookie();
                string username = GetUsernameFromCookie();
                bool isAdmin = Classes.BLs.Common.CommonBL.IsUserAdmin(username);
                ViewBag.IsAdmin = isAdmin;
                Models.About.AboutViewModel model = new Models.About.AboutViewModel(fullName);
                ViewBag.IsValidSession = true;
                return View(model);
            }
        }

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

        public ActionResult Registration()
        {
            Models.Registration.RegistrationViewModel model = new Models.Registration.RegistrationViewModel();
            return View(model);
        }

        //[HttpPost]
        public ActionResult RegisterUser(Models.Registration.RegistrationViewModel model) {
            Classes.BLs.RegistrationBL.RegistrationStatus status = Classes.BLs.RegistrationBL.RegisterUser(model);

            switch (status)
            {
                case Classes.BLs.RegistrationBL.RegistrationStatus.UserExists:
                    model.ErrorMsg = Classes.Consts.Registration.UserExists;
                    return View("Registration", model);
                case Classes.BLs.RegistrationBL.RegistrationStatus.InvalidPassword:
                    model.ErrorMsg = Classes.Consts.Registration.InvalidPassword;
                    return View("Registration", model);
                case Classes.BLs.RegistrationBL.RegistrationStatus.InvalidEmail:
                    model.ErrorMsg = Classes.Consts.Registration.InvalidEmail;
                    return View("Registration", model);
                case Classes.BLs.RegistrationBL.RegistrationStatus.Success:
                    Models.Login.LoginViewModel loginModel = new Models.Login.LoginViewModel();
                    loginModel.SuccessMsg = Classes.Consts.Registration.Success;
                    return View("Login", loginModel);
                default:
                    throw new NotImplementedException("Login exception");
            }
        }


        public ActionResult Login()
        {
            Models.Login.LoginViewModel model = new Models.Login.LoginViewModel();
            var valid = IsSessionValid();
            if (valid)
            {
                Response.Redirect("Home");
            }
            
            return View(model);
        }

        public ActionResult LoginUser(Models.Login.LoginViewModel model)
        {
            Classes.BLs.LoginBL.LoginStatus status = Classes.BLs.LoginBL.LoginUser(model);
            switch (status)
            {
                case Classes.BLs.LoginBL.LoginStatus.InvalidUsername:
                    model.ErrorMsg = Classes.Consts.Registration.InvalidUsername;
                    return View("Login", model);
                case Classes.BLs.LoginBL.LoginStatus.InvalidPassword:
                    model.ErrorMsg = Classes.Consts.Registration.InvalidPassword;
                    return View("Login", model);
                case Classes.BLs.LoginBL.LoginStatus.Success:
                    CreateSession(model.Username); //v sejo zapišeš username od uporabnika, da veš kdo je kdo
                    //Response.Redirect("Home", false);
                    //return View("Login", model);
                    return RedirectToAction("Home");

                default:
                    throw new NotImplementedException("Login exception");
            }
        }
        
        public ActionResult LogOutUser()
        {
            DestroySession();
            //Response.Redirect("Index");
            //return View("Index");
            return RedirectToAction("Index");
        }

        public ActionResult ItemDetails(Models.ItemDetails.ItemDetailsViewModel model, string code, string command) //edit za admina
        {
            var valid = IsSessionValid();
            bool isAdmin = false;

            if (valid)
            {
                var username = GetUsernameFromCookie();
                isAdmin = Classes.BLs.Common.CommonBL.IsUserAdmin(username);
            }

            ViewBag.IsAdmin = false; //reset
            if (!valid)
            {
                ViewBag.IsValidSession = false;
                model = new Models.ItemDetails.ItemDetailsViewModel(null, code);
                return View(model);
            }
            else
            {
                ViewBag.IsValidSession = true;
                if (isAdmin) ViewBag.IsAdmin = true;
                string fullName = GetFullNameFromCookie();
                if (command == "Shrani")
                {
                    bool success = Classes.BLs.Common.CommonBL.UpdateItem(model.Item);
                    if (success)
                    {
                        //uspešno shranjeno
                    }
                    //ModelState.Clear();
                    //model na novo potegni iz baze!!
                    code = model.Item.IdentificationCode; //da dobiš isti item notr
                    model = new Models.ItemDetails.ItemDetailsViewModel(fullName, code); 
                    return View(model);
                }
                else if (String.IsNullOrEmpty(command)) //GET first time
                {
                    //if (code == null) code = model.Item.IdentificationCode; //zaradi refreshinga

                    model = new Models.ItemDetails.ItemDetailsViewModel(fullName, code);
                    return View(model);
                }
                else
                {
                    throw new NotImplementedException();
                }

            }
        }

        public ActionResult AddItem(Models.AddItem.AddItemViewModel model, string command)
        {
            //za edit morš met še id
            var valid = IsSessionValid();
            var username = GetUsernameFromCookie();
            var fullName = GetFullNameFromCookie();
            bool isAdmin = Classes.BLs.Common.CommonBL.IsUserAdmin(username);

            if (!valid || !isAdmin)
            {
                InvalidSessionRedirect();
                return View("Index");
            }

            if (command == "Shrani")
            {
                bool success = Classes.BLs.Common.CommonBL.SaveItem(model.Item);
                if (success)
                {
                    //uspešno shranjeno
                }

                //redirect na AddItem---Edit
                return View();
            }
            else if (String.IsNullOrEmpty(command)) //GET first time
            {
                model = new Models.AddItem.AddItemViewModel(fullName);
                return View(model);
            }
            else
            {
                throw new NotImplementedException();
        }
    }


        public ActionResult Home()
        {
            var valid = IsSessionValid();
            if (!valid)
            {
                return RedirectToAction("Index");
            }
            else
            {
                string fullName = GetFullNameFromCookie();
                string username = GetUsernameFromCookie();
                bool isAdmin = Classes.BLs.Common.CommonBL.IsUserAdmin(username);
                ViewBag.IsAdmin = isAdmin;
                //morjo bit vsaj 3 v bazi!, username zato, ker je enoličen in lahko preko njega dobim rente za userja
                Models.Home.HomeViewModel model = new Models.Home.HomeViewModel(fullName, username, Classes.BLs.HomeBL.GenerateCodes());
                return View(model);
            }
        }

        public ActionResult Search()
        {
            var valid = IsSessionValid();
            if (!valid)
            {
                //InvalidSessionRedirect();
                ViewBag.IsValidSession = false;
                return View();
            }
            else
            {
                string fullName = GetFullNameFromCookie();
                string username = GetUsernameFromCookie();
                bool isAdmin = Classes.BLs.Common.CommonBL.IsUserAdmin(username);
                ViewBag.IsAdmin = isAdmin;
                Models.Search.SearchViewModel model = new Models.Search.SearchViewModel(fullName);
                ViewBag.IsValidSession = true;
                return View(model);
            }
        }

        public ActionResult Statistics()
        {
            var valid = IsSessionValid();
            if (!valid)
            {
                InvalidSessionRedirect();
                return View();
            }
            else
            {
                string fullName = GetFullNameFromCookie();
                string username = GetUsernameFromCookie();
                bool isAdmin = Classes.BLs.Common.CommonBL.IsUserAdmin(username);
                ViewBag.IsAdmin = isAdmin;
                Models.Statistics.StatisticsViewModel model = new Models.Statistics.StatisticsViewModel(fullName);
                return View(model);
            }
        }

        public ActionResult Recommend()
        {
            var valid = IsSessionValid();
            if (!valid)
            {
                InvalidSessionRedirect();
                return View();
            }
            else
            {
                string fullName = GetFullNameFromCookie();
                Models.Recommend.RecommendViewModel model = new Models.Recommend.RecommendViewModel(fullName);
                return View(model);
            }
        }

        //only for admin
        public JsonResult ReturnItem(string code)
        {
            var valid = IsSessionValid();
            var username = GetUsernameFromCookie();
            bool isAdmin = Classes.BLs.Common.CommonBL.IsUserAdmin(username);
            if (valid && isAdmin)
            {
                Classes.BLs.Common.CommonBL.ReturnItem(code, username);
                var json = new JsonResult();
                json.Data = new { redirectTo = Url.Action("ItemDetails", "Home", new { code = code }) }; //ostale dva parametrta sta null, tretiraš kot prvi dostop
                return json;
            }
            else
            {
                //TODO invalid session
                var json = new JsonResult();
                json.Data = new { redirectTo = Url.Action("Index", "Home", null) };
                return json;
            }
        }

        public JsonResult RentItem(string code)
        {
            var valid = IsSessionValid();

            if (valid)
            {
                var username = GetUsernameFromCookie();
                Classes.BLs.Common.CommonBL.RentItem(code, username);
                var json = new JsonResult();
                json.Data = new { redirectTo = Url.Action("Home", "Home", null) };
                return json;
            }
            else
            {
                //TODO invalid session
                RedirectToAction("Index");
                return null;
            }
        }

        /****************PRIVATE METHODS******************************/

        private bool IsSessionValid()
        {
            var authId = Request.Cookies.Get(Classes.Consts.Session.CookieName);
            if (authId == null)
            {
                return false;
            }
            if (authId.Value.ToString() != Session[Classes.Consts.Session.CookieName] as string)
            {
                return false;
            }
            return true;
        }

        private string GetUsernameFromCookie()
        {
            string authId = Request.Cookies.Get(Classes.Consts.Session.CookieName).Value.ToString();
            string username = Session[authId].ToString();
            return username;
        }

        private string GetFullNameFromCookie()
        {
            string authId = Request.Cookies.Get(Classes.Consts.Session.CookieName).Value.ToString();
            string username = Session[authId].ToString();
            string fullName = Classes.BLs.Common.CommonBL.GetUserFullNameFromUsername(username);
            if (fullName == null)
            {
                throw new NotImplementedException("fullName == null");
            }
            return fullName;
        }

        private void CreateSession(string username)
        {
            string authId = Guid.NewGuid().ToString();

            Session[Classes.Consts.Session.CookieName] = authId;
            Session[authId] = username;//v sejo shranim username

            HttpCookie cookie = new HttpCookie(Classes.Consts.Session.CookieName);
            cookie.Value = authId;
            Response.SetCookie(cookie);
        }

        private void InvalidSessionRedirect()
        {
            Response.Redirect("Index");
        }

        private void DestroySession()
        {
            string authId = Request.Cookies.Get(Classes.Consts.Session.CookieName).Value.ToString();
            //Session[authId] = null;
            HttpCookie cookie = new HttpCookie(Classes.Consts.Session.CookieName);
            cookie.Value = authId;
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.SetCookie(cookie);
        }
    }
}