using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPMVCProject.Models;
using ASPMVCProject.Helpers;
using Repositories;
using DataAccess;

namespace ASPMVCProject.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {

            if (LoginUserSession.Current.IsAuthenticated) return RedirectToAction("Index", "Home");

            LoginViewModel model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            UserRepository repo = new UserRepository();

            User user = repo.GetUserByNameAndPassword(model.Username, model.Password);

            if (null != user)
            {

                LoginUserSession.Current.SetCurrentUser(user.ID, user.Username, user.Username == "admin");

                return RedirectToAction("Index", "Home");
            }

            return Login();
        }

        [HttpGet]
        public ActionResult Register()
        {

            if (LoginUserSession.Current.IsAuthenticated) return RedirectToAction("Index", "Home");

            LoginViewModel model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(LoginViewModel model)
        {
            UserRepository repo = new UserRepository();
            User user = repo.GetUserByName(model.Username);
            if (null == user)
            {
                user = new User();
                user.Username = model.Username;
                repo.RegisterUser(user, model.Password);
                LoginUserSession.Current.SetCurrentUser(user.ID, user.Username, user.Username == "admin");
                TempData["Message"] = "Successfully registered!";
                return RedirectToAction("Index", "Home");
            }

            TempData["ErrorMessage"] = "Username already exists!";
            return Register();
        }

        public ActionResult Logout()
        {
            LoginUserSession.Current.Logout();
            return RedirectToAction("Index", "Home");
        }

    }
}