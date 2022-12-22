using BLL.Interfaces;
using GamingPlatform.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GamingPlatform.ViewModels
{
    public class InfoAboutGameViewModel : INotifyPropertyChanged
    {
        private IDbCrud db;
        private InfoAboutGame infoAboutGame;
        public int pointer { get; set; }

        private GameModel game;
        public GameModel Game 
        {
            get { return game; }
            set
            {
                game = value;
                OnPropertyChanged("Game");
            }
        }
        public UserModel User { get; set; }

        private string vis;
        public string Vis
        {
            get { return vis; }
            set
            {
                vis = value;
                OnPropertyChanged("Vis");
            }
        }

        public InfoAboutGameViewModel(IDbCrud dbCrud, GameModel game, UserModel user, InfoAboutGame infoAboutGame, int pointer)
        {
            db = dbCrud;
            Game = game;
            User = user;
            this.pointer = pointer;
            this.infoAboutGame = infoAboutGame;
            Vis = "Visible";

            Check();
        }

        public void Check()
        {
            GamePurchaseModel purchase = new GamePurchaseModel();
            purchase = db.GetPurchase()
                .Where(i => i.UserId == User.Id && i.GameId == Game.Id)
                .Select(i => new GamePurchaseModel(i)).FirstOrDefault();

            if (purchase != null) Vis = "Collapsed";
        }

        private RelayCommand _buyGame;
        public RelayCommand BuyGame
        {
            get { return _buyGame ?? (_buyGame = new RelayCommand(obj => Purchase())); }
            set 
            { 
                _buyGame = value; 
                OnPropertyChanged("BuyGame");
            }
        }

        public void Purchase()
        {
            WindowPurchase winPurchase = new WindowPurchase(db, Game, User);
            winPurchase.ShowDialog();

            Vis = "Collapsed";

            infoAboutGame.NavigationService.Refresh();
        }

        private RelayCommand _backPlayStore;
        public RelayCommand BackPlayStore
        {
            get { return _backPlayStore ?? (_backPlayStore = new RelayCommand(obj => BackList())); }
            set
            {
                _backPlayStore = value;
                OnPropertyChanged("BackPlayStore");
            }
        }

        public void BackList()
        {
            if (pointer == 0)
                infoAboutGame.NavigationService.Navigate(new Home());
            else if (pointer == 1)
                infoAboutGame.NavigationService.Navigate(new PlayStore());
            else if (pointer == 2) 
                infoAboutGame.NavigationService.Navigate(new GameList(User));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
