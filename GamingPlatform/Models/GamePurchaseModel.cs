using BLL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingPlatform.Models
{
    public class GamePurchaseModel : INotifyPropertyChanged
    {
        public int id;
        public int gameId;
        public DateTime purchaseDate;
        public int statusBuyId;
        public int userId;
        public decimal purchasePrice;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public int GameId
        {
            get { return gameId; }
            set
            {
                gameId = value;
                OnPropertyChanged("GameId");
            }
        }
        public DateTime PurchaseDate
        {
            get { return purchaseDate; }
            set
            {
                purchaseDate = value;
                OnPropertyChanged("PurchaseDate");
            }
        }
        public int StatusBuyId
        {
            get { return statusBuyId; }
            set
            {
                statusBuyId = value;
                OnPropertyChanged("StatusBuyId");
            }
        }
        public int UserId
        {
            get { return userId; }
            set
            {
                userId = value;
                OnPropertyChanged("UserId");
            }
        }
        public decimal PurchasePrice
        {
            get { return purchasePrice; }
            set
            {
                purchasePrice = value;
                OnPropertyChanged("PurchasePrice");
            }
        }

        public GamePurchaseModel() { }

        public GamePurchaseModel(GamePurchaseDTO purchase)
        {
            Id = purchase.Id;
            GameId = purchase.GameId;
            PurchaseDate = purchase.PurchaseDate;
            StatusBuyId = purchase.StatusBuyId;
            UserId = purchase.UserId;
            PurchasePrice = purchase.PurchasePrice;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
