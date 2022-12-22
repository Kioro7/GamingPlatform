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
    public class GameRepositorySQL : IRepository<Game>
    {
        private GamingPlatform gp;

        public GameRepositorySQL(GamingPlatform dbcontext)
        {
            gp = dbcontext;
        }

        public List<Game> GetList()
        {
            return gp.Game.ToList();
        }

        public Game GetItem(int id)
        {
            return gp.Game.Find(id);
        }

        public void Create(Game obj)
        {
            gp.Game.Add(obj);
        }

        public void Update(Game obj)
        {
            gp.Entry(obj).State = EntityState.Modified;
        }
    }
}
