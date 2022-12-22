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
    public class StGPurchRepositorySQL : IRepository<StatusGamePurchase>
    {
        private GamingPlatform gp;

        public StGPurchRepositorySQL(GamingPlatform dbcontext)
        {
            gp = dbcontext;
        }

        public List<StatusGamePurchase> GetList()
        {
            return gp.StatusGamePurchase.ToList();
        }

        public StatusGamePurchase GetItem(int id)
        {
            return gp.StatusGamePurchase.Find(id);
        }

        public void Create(StatusGamePurchase obj)
        {
            gp.StatusGamePurchase.Add(obj);
        }

        public void Update(StatusGamePurchase obj)
        {
            gp.Entry(obj).State = EntityState.Modified;
        }
    }
}
