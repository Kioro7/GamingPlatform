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
    public class MessageRepositorySQL : IRepository<Message>
    {
        private GamingPlatform gp;

        public MessageRepositorySQL(GamingPlatform dbcontext)
        {
            gp = dbcontext;
        }

        public List<Message> GetList()
        {
            return gp.Message.ToList();
        }

        public Message GetItem(int id)
        {
            return gp.Message.Find(id);
        }

        public void Create(Message obj)
        {
            gp.Message.Add(obj);
        }

        public void Update(Message obj)
        {
            gp.Entry(obj).State = EntityState.Modified;
        }

    }
}
