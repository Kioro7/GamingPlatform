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
    public class HomeViewModel : INotifyPropertyChanged
    {
        private IDbCrud db;
        private Home HomePage;

        private ObservableCollection<GameModel> gamesList;
        public ObservableCollection<GameModel> GamesList
        {
            get { return gamesList; }
            set
            {
                gamesList = value;
                OnPropertyChanged("GamesList");
            }
        }

        public HomeViewModel(IDbCrud db, Home home)
        {
            this.db = db;
            this.HomePage = home;

            GLOBAL.User = db.GetUsers().Where(i => i.Id == 2).Select(i => new UserModel(i)).FirstOrDefault();

            GamesLoad();
        }

        public void GamesLoad()
        {
            List<GenreModel> genres = db.GetGenre().Select(i => new GenreModel(i)).ToList();
            GamesList = new ObservableCollection<GameModel>(db.GetGames().OrderByDescending(i => i.Rating).Take(3).Select(i => new GameModel(i, genres)).ToList());
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

            HomePage.NavigationService.Navigate(new InfoAboutGame(db, game, GLOBAL.User, 0));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
