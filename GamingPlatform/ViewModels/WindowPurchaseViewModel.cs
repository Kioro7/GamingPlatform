using BLL.DTO;
using BLL.Interfaces;
using GalaSoft.MvvmLight.Messaging;
using GamingPlatform.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GamingPlatform.ViewModels
{
    public class WindowPurchaseViewModel : INotifyPropertyChanged
    {
        IDbCrud db;
        IPurchaseService purchaseService;

        public GameModel Game { get; set; }
        public UserModel User { get; set; }
        public Action CloseAction { get; set; }

        private StatusGamePurchaseModel statusPurchase;
        public StatusGamePurchaseModel Status
        {
            get { return statusPurchase; }
            set
            {
                statusPurchase = value;
                OnPropertyChanged("Status");
            }
        }
        public DateTime Date { get; set; }

        private string visb;
        public string VisB
        {
            get { return visb; }
            set
            {
                visb = value;
                OnPropertyChanged("VisB");
            }
        }

        private string visa;
        public string VisA
        {
            get { return visa; }
            set
            {
                visa = value;
                OnPropertyChanged("VisA");
            }
        }

        public WindowPurchaseViewModel(IDbCrud dbCrud, IPurchaseService purchServ, GameModel game, UserModel user)
        {
            db = dbCrud;
            purchaseService = purchServ;

            Game = game;
            User = user;
            Status = new StatusGamePurchaseModel();
            Date = DateTime.Now;
            VisB = "Visible";
            VisA = "Collapsed";
        }

        private RelayCommand _addPurchase;
        public RelayCommand AddPurchase 
        { 
            get { return _addPurchase ?? (_addPurchase = new RelayCommand(obj => NewPurchase())); } 
            set 
            { 
                _addPurchase = value;
                OnPropertyChanged("AddPurchase");
            }
        }

        public void NewPurchase()
        {
            VisB = "Collapsed";
            VisA = "Visible";

            GamePurchaseModel purchase = new GamePurchaseModel();

            purchase = db.GetPurchase()
                .Where(i => i.UserId == User.Id && i.GameId == Game.Id)
                .Select(i => new GamePurchaseModel(i)).FirstOrDefault();

            if (purchase == null)
                if (User.Balance >= Game.Price)
                {
                    Status = db.GetStatusBuy()
                        .Where(i => i.Id == 1)
                        .Select(i => new StatusGamePurchaseModel(i)).FirstOrDefault();

                    GamePurchaseDTO purch = new GamePurchaseDTO()
                    {
                        GameId = Game.Id,
                        PurchaseDate = DateTime.Now,
                        UserId = User.Id,
                        StatusBuyId = Status.Id,
                        PurchasePrice = Game.Price
                    };

                    User.Balance -= Game.Price;

                    UserDTO user = new UserDTO()
                    {
                        Id = User.Id,
                        UserTypeId = User.UserTypeId,
                        Nickname = User.Nickname,
                        Birthday = User.Birthday,
                        Email = User.Email,
                        Password = User.Password,
                        Balance = User.Balance
                    };

                    GLOBAL.User = User;
                    db.UpdateUser(user);
                    purchaseService.AddNewGamePurchase(purch);
                }
                else if (User.Balance < Game.Price)
                {
                    Status = db.GetStatusBuy()
                        .Where(i => i.Id == 3)
                        .Select(i => new StatusGamePurchaseModel(i)).FirstOrDefault();
                }
            else Status = db.GetStatusBuy()
                        .Where(i => i.Id == 3)
                        .Select(i => new StatusGamePurchaseModel(i)).FirstOrDefault();
        }

        private RelayCommand _close;
        public RelayCommand Close
        {
            get { return _close ?? (_close = new RelayCommand(obj => CloseWindow())); }
            set
            {
                _close = value;
                OnPropertyChanged("Close");
            }
        }

        public void CloseWindow()
        {
            VisB = "Visible";
            VisA = "Collapsed";
            CloseAction();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
