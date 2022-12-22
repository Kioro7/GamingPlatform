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
    public class GenreRepositorySQL : IRepository<Genre>
    {
        private GamingPlatform gp;

        public GenreRepositorySQL(GamingPlatform dbcontext)
        {
            gp = dbcontext;
        }

        public List<Genre> GetList()
        {
            return gp.Genre.ToList();
        }

        public Genre GetItem(int id)
        {
            return gp.Genre.Find(id);
        }

        public void Create(Genre obj)
        {
            gp.Genre.Add(obj);
        }

        public void Update(Genre obj)
        {
            gp.Entry(obj).State = EntityState.Modified;
        }
    }
}
