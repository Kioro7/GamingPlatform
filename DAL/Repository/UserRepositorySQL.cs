using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UserRepositorySQL : IRepository<User>
    {
        private GamingPlatform gp;

        public UserRepositorySQL(GamingPlatform dbcontext)
        {
            gp = dbcontext;
        }

        public List<User> GetList()
        {
            return gp.User.ToList();
        }

        public User GetItem(int id)
        {
            return gp.User.Find(id);
        }

        public void Create(User obj)
        {
            gp.User.Add(obj);
        }

        public void Update(User obj)
        {
            gp.Entry(obj).State = EntityState.Modified;
        }
    }
}
