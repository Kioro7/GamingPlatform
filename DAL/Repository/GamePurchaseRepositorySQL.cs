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
    public class GamePurchaseRepositorySQL : IRepository<GamePurchase>
    {
        private GamingPlatform gp;

        public GamePurchaseRepositorySQL(GamingPlatform dbcontext)
        {
            gp = dbcontext;
        }

        public List<GamePurchase> GetList()
        {
            return gp.GamePurchase.ToList();
        }

        public GamePurchase GetItem(int id)
        {
            return gp.GamePurchase.Find(id);
        }

        public void Create(GamePurchase obj)
        {
            gp.GamePurchase.Add(obj);
        }

        public void Update(GamePurchase obj)
        {
            gp.Entry(obj).State = EntityState.Modified;
        }
    }
}
