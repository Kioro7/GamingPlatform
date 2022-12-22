using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDbCrud
    {
        List<GameDTO> GetGames();
        GameDTO GetGameItem(int id);
        UserDTO GetUserItem(int id);
        List<GenreDTO> GetGenre();
        List<ModeDTO> GetModes();
        List<UserDTO> GetUsers();
        List<GamePurchaseDTO> GetPurchase();
        List<StatusGamePurchaseDTO> GetStatusBuy();
        void AddGenre(GenreDTO g);
        void AddGame(GameDTO g);
        void AddGamePurchase(GamePurchaseDTO gamePurchase);
        void UpdateUser(UserDTO u);
        bool Save();
    }
}
