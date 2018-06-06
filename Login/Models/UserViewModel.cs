using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;

namespace ASPMVCProject.Models
{


    public class UsersViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public UsersViewModel(int id, string name)
        {
            ID = id;
            Name = name;
        }

    }

    public class UserViewModel
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public List<UsersViewModel> usersList;

        public UserViewModel()
        {
            usersList = new List<UsersViewModel>();
        }

        public UserViewModel(User user)
        {
            ID = user.ID;
            Username = user.Username;
        }

        public UserViewModel(List<User> users)
            : this()
        {
            foreach (User user in users)
            {
                usersList.Add(new UsersViewModel(user.ID, user.Username));
            }
        }
    }
}
