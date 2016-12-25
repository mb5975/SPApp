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
        {
            return View();
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
            var isRegisteredSuccessfully = Classes.BLs.RegistrationBL.RegisterUser(model);
            if (isRegisteredSuccessfully)
            {
                Models.Login.LoginViewModel loginModel = new Models.Login.LoginViewModel();
                loginModel.SuccessMsg = Classes.Consts.Registration.Success;
                return View("Login", loginModel);
            }
            else
            {
                model.ErrorMsg = Classes.Consts.Registration.Failed;
                return View("Registration", model);
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
                    Response.Redirect("Home", false);
                    return View("Index");

                default:
                    throw new NotImplementedException("Login exception");
            }
        }
        
        public ActionResult LogOutUser()
        {
            DestroySession();
            Response.Redirect("Index");
            return View("Index");
        }

        public ActionResult ItemDetails()
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
                Models.ItemDetails.ItemDetailsViewModel model = new Models.ItemDetails.ItemDetailsViewModel(fullName);
                ViewBag.IsValidSession = true;
                return View(model);
            }
        }

        public ActionResult Home()
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
                Models.Home.HomeViewModel model = new Models.Home.HomeViewModel(fullName);
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