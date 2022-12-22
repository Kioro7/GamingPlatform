using BLL.DTO;
using BLL.Interfaces;
using GamingPlatform.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GamingPlatform.ViewModels
{
    public class GameListViewModel : INotifyPropertyChanged
    {
        IDbCrud db;
        private GameList listPage;

        private UserModel user;

        private ObservableCollection<GameModel> _myList;
        public ObservableCollection<GameModel> MyList
        {
            get { return _myList ?? (_myList = LoadUserList()); }
            set
            {
                _myList = value;
                OnPropertyChanged("GamesList");
            }
        }

        public GameListViewModel(IDbCrud db, UserModel user, GameList listPage)
        {
            this.db = db;
            this.user = user;

            LoadUserList();
            this.listPage = listPage;
        }

        public ObservableCollection<GameModel> LoadUserList()
        {
            List<GenreModel> genre = db.GetGenre().Select(i => new GenreModel(i)).ToList();

            List<GamePurchaseModel> purch = db.GetPurchase()
                .Where(i => i.UserId == user.Id && i.StatusBuyId == 1)
                .Select(i => new GamePurchaseModel(i))
                .ToList();

            MyList = new ObservableCollection<GameModel>();

            foreach (GamePurchaseModel purchase in purch)
            {
                GameModel item = db.GetGames()
                    .Where(i => i.Id == purchase.GameId)
                    .Select(i => new GameModel(i, genre))
                    .FirstOrDefault();
                if (item != null) MyList.Add(item);
            }

            return MyList;
        }

        private RelayCommand _chooseGame;
        public RelayCommand ChooseGame
        {
            get { return _chooseGame ?? (_chooseGame = new RelayCommand(obj => ShowGameInfo(obj))); }
        }

        public void ShowGameInfo(object obj)
        {
            int id = (int)obj;
            List<GenreModel> genres = db.GetGenre().Select(i => new GenreModel(i)).ToList();
            GameModel game = new GameModel(db.GetGameItem(id), genres);

            listPage.NavigationService.Navigate(new InfoAboutGame(db, game, user, 2));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
