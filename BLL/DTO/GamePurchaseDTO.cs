using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class GamePurchaseDTO
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int StatusBuyId { get; set; }
        public int UserId { get; set; }
        public decimal PurchasePrice { get; set; }

        public GamePurchaseDTO() { }

        public GamePurchaseDTO(GamePurchase purchase)
        {
            Id = purchase.Id;
            GameId = purchase.GameId;
            PurchaseDate = purchase.PurchaseDate;
            StatusBuyId = purchase.StatusBuyId;
            UserId = purchase.UserId;
            PurchasePrice = purchase.PurchasePrice;
        }
    }
}
