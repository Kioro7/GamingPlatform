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
    public class UserTypeRepositorySQL : IRepository<UserType>
    {
        private GamingPlatform gp;

        public UserTypeRepositorySQL(GamingPlatform dbcontext)
        {
            gp = dbcontext;
        }

        public List<UserType> GetList()
        {
            return gp.UserType.ToList();
        }

        public UserType GetItem(int id)
        {
            return gp.UserType.Find(id);
        }

        public void Create(UserType obj)
        {
            gp.UserType.Add(obj);
        }

        public void Update(UserType obj)
        {
            gp.Entry(obj).State = EntityState.Modified;
        }
    }
}
