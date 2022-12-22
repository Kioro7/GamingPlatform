using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PurchaseService : IPurchaseService
    {
        private IDbRepos db;

        public PurchaseService(IDbRepos repos)
        {
            db = repos;
        }

        public void AddNewGamePurchase(GamePurchaseDTO gamePurchase)
        {
            db.gPurch.Create(new GamePurchase()
            {
                GameId = gamePurchase.GameId,
                StatusBuyId = gamePurchase.StatusBuyId,
                UserId = gamePurchase.UserId,
                PurchaseDate = gamePurchase.PurchaseDate,
                PurchasePrice = gamePurchase.PurchasePrice
            });

            db.Save();
        }
    }
}
