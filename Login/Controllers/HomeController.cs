using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using Repositories;
using Login.Models;

namespace Login.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AllUsers()
        {
            UserRepository repo = new UserRepository();
            List<User> users = repo.GetAll();

            LoginViewModel model = new LoginViewModel(users);


            return View(model);
        }

        [HttpGet]
        public ActionResult Register()
        {
            LoginViewModel model = new LoginViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Register(LoginViewModel user)
        {
            UserRepository repo = new UserRepository();

            User dbUser = new DataAccess.User
            {
                Username = user.Username,
                Password = user.Password
            };

            repo.Save(dbUser);

            return Redirect("Index");
        }


        [HttpGet]
        public ActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel user)
        {

            UserRepository repo = new UserRepository();

            User dbUser = repo.GetUserByUsername(user.Username);

            if(dbUser == null)
            {
                return Redirect("Login");
            }

            if(dbUser.Password == user.Password)
            {
                Session["Username"] = user.Username;
                return Redirect("Index");
            }


            return Redirect("Login");

        }

    }
}