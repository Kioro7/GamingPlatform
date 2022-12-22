using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class DbReposSQL : IDbRepos
    {
        GamingPlatform db;
        GamePurchaseRepositorySQL GamePurchaseRepository;
        GameRepositorySQL GameRepository;
        GenreRepositorySQL GenreRepository;
        MessageRepositorySQL MessageRepository;
        ModeRepositorySQL ModeRepository;
        StGPurchRepositorySQL StGPurchRepository;
        UserRepositorySQL UserRepository;
        UserTypeRepositorySQL UserTypeRepository;

        public DbReposSQL()
        {
            db = new GamingPlatform();
        }
        public IRepository<GamePurchase> gPurch
        {
            get
            {
                if (GamePurchaseRepository == null) GamePurchaseRepository = new GamePurchaseRepositorySQL(db);
                return GamePurchaseRepository;
            }
        }
        public IRepository<Game> games
        {
            get
            {
                if (GameRepository == null) GameRepository = new GameRepositorySQL(db);
                return GameRepository;
            }
        }
        public IRepository<Genre> genres
        {
            get
            {
                if (GenreRepository == null) GenreRepository = new GenreRepositorySQL(db);
                return GenreRepository;
            }
        }
        public IRepository<Message> mess
        {
            get
            {
                if (MessageRepository == null) MessageRepository = new MessageRepositorySQL(db);
                return MessageRepository;
            }
        }
        public IRepository<Mode> modes
        {
            get
            {
                if (ModeRepository == null) ModeRepository = new ModeRepositorySQL(db);
                return ModeRepository;
            }
        }
        public IRepository<StatusGamePurchase> stGPurch
        {
            get
            {
                if (StGPurchRepository == null) StGPurchRepository = new StGPurchRepositorySQL(db);
                return StGPurchRepository;
            }
        }
        public IRepository<User> users
        {
            get
            {
                if (UserRepository == null) UserRepository = new UserRepositorySQL(db);
                return UserRepository;
            }
        }
        public IRepository<UserType> usersType
        {
            get
            {
                if (UserTypeRepository == null) UserTypeRepository = new UserTypeRepositorySQL(db);
                return UserTypeRepository;
            }
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
