using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDbRepos
    {
        IRepository<Game> games { get; }
        IRepository<GamePurchase> gPurch { get; }
        IRepository<Genre> genres { get; }
        IRepository<Message> mess { get; }
        IRepository<Mode> modes { get; }
        IRepository<StatusGamePurchase> stGPurch { get; }
        IRepository<User> users { get; }
        IRepository<UserType> usersType { get; }
        int Save();
    }
}
