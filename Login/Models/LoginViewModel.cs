using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;

namespace Login.Models
{

    public class LoginsViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginsViewModel(string username, string password)
        {
            Username = username;
            Password = password;
        }

    }

    public class LoginViewModel
    {

        public string Username { get; set; }
        public string Password { get; set; }

        public List<LoginsViewModel> loginList;

        public LoginViewModel()
        {
            loginList = new List<LoginsViewModel>();
        }

        public LoginViewModel(List<User> users)
            : this()
        {
            foreach (User user in users)
            {
                loginList.Add(new LoginsViewModel(user.Username, user.Password));
            }
        }



    }
}