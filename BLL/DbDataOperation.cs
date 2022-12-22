using BLL.DTO;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DbDataOperation : IDbCrud
    {
        IDbRepos gpContext;

        public DbDataOperation(IDbRepos repos)
        {
            gpContext = repos;
        }

        public List<GameDTO> GetGames()
        {
            return gpContext.games.GetList().Select(i => new GameDTO(i)).ToList();
        }

        public GameDTO GetGameItem(int id)
        {
            return new GameDTO(gpContext.games.GetItem(id));
        }

        public List<GenreDTO> GetGenre()
        {
            return gpContext.genres.GetList().Select(i => new GenreDTO(i)).ToList();
        }

        public List<ModeDTO> GetModes()
        {
            return gpContext.modes.GetList().Select(i => new ModeDTO(i)).ToList();
        }

        public List<UserDTO> GetUsers()
        {
            return gpContext.users.GetList().Select(i => new UserDTO(i)).ToList();
        }

        public UserDTO GetUserItem(int id)
        {
            return new UserDTO(gpContext.users.GetItem(id));
        }

        public List<GamePurchaseDTO> GetPurchase()
        {
            return gpContext.gPurch.GetList().Select(i => new GamePurchaseDTO(i)).ToList();
        }

        public List<StatusGamePurchaseDTO> GetStatusBuy()
        {
            return gpContext.stGPurch.GetList().Select(i => new StatusGamePurchaseDTO(i)).ToList();
        }

        public void AddGenre(GenreDTO g)
        {
            gpContext.genres.Create(new Genre()
            {
                Name = g.GenreName
            });
            Save();
        }

        public void AddGame(GameDTO g)
        {
            gpContext.games.Create(new Game()
            {
                Name = g.Name,
                GenreId = g.GenreId,
                ModeId = g.ModeId,
                ReleaseDate = g.ReleaseDate,
                Price = g.Price,
                Developer = g.Developer,
                RegistrationDate = g.RegistrationDate,
            });
            Save();
        }

        public void AddGamePurchase(GamePurchaseDTO gamePurchase)
        {
            gpContext.gPurch.Create(new GamePurchase()
            {
                GameId = gamePurchase.GameId,
                StatusBuyId = gamePurchase.StatusBuyId,
                UserId = gamePurchase.UserId,
                PurchaseDate = gamePurchase.PurchaseDate,
                PurchasePrice = gamePurchase.PurchasePrice
            });
            Save();
        }

        public void UpdateUser(UserDTO u)
        {
            User user = new User();
            user = gpContext.users.GetItem(u.Id);
            user.Nickname = u.Nickname;
            user.Birthday = u.Birthday;
            user.Email = u.Email;
            user.Password = u.Password;
            user.Balance = u.Balance;
            gpContext.users.Update(user);
            Save();
        }

        public bool Save()
        {
            if (gpContext.Save() > 0) return true;
            return false;
        }
    }
}
