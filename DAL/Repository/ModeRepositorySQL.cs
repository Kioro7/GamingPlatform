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
    public class ModeRepositorySQL : IRepository<Mode>
    {
        private GamingPlatform gp;

        public ModeRepositorySQL(GamingPlatform dbcontext)
        {
            gp = dbcontext;
        }

        public List<Mode> GetList()
        {
            return gp.Mode.ToList();
        }

        public Mode GetItem(int id)
        {
            return gp.Mode.Find(id);
        }

        public void Create(Mode obj)
        {
            gp.Mode.Add(obj);
        }

        public void Update(Mode obj)
        {
            gp.Entry(obj).State = EntityState.Modified;
        }
    }
}
