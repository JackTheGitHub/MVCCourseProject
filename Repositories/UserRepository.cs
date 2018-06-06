using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Repositories
{
    public class UserRepository : BaseRepository<User>
    {

        public User GetUserByUsername(string username)
        {

            return GetAll().Where(u => u.Username == username).FirstOrDefault();

        }

        public override void Save(User user)
        {
            if (user.ID == 0)
            {
                base.Create(user);
            }
            else
            {
                base.Update(user, item => item.ID == user.ID);
            }
        }
    }
}
