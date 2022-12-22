using BLL.DTO;
using BLL.Interfaces;
using GamingPlatform.Models;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace GamingPlatform.ViewModels
{
    public class PlayStoreViewModel : INotifyPropertyChanged
    {
        private UserModel user;

        private IDbCrud db;
        private PlayStore PlayStorePage;

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
        public List<GenreModel> Genres { get; set; }

        private GenreModel selectedGenre;
        public GenreModel SelectedGenre
        {
            get { return selectedGenre; }
            set
            {
                selectedGenre = value;
                OnPropertyChanged("SelectedGenre");
            }
        }

        private ModeModel selectedMode;
        public ModeModel SelectedMode
        {
            get { return selectedMode; }
            set
            {
                selectedMode = value;
                OnPropertyChanged("SelectedMode");
            }
        }

        public List<ModeModel> Modes { get; set; }

        private GameModel _selectedGame;
        public GameModel SelectedGame
        {
            get { return _selectedGame; }
            set
            {
                _selectedGame = value;
                OnPropertyChanged("SelectedGame");
            }
        }

        private Page _currentPage;
        public Page CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }

        private int _selectedItem;
        public int SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value; }
        }

        public PlayStoreViewModel(IDbCrud dbCrud, PlayStore page)
        {
            db = dbCrud;
            PlayStorePage = page;

            _selectedItem = -1;

            user = db.GetUsers().Where(i => i.Id == 2).Select(i => new UserModel(i)).FirstOrDefault();

            GamesLoad();
            GenreLoad();
            ModeLoad();
        }

        public void GamesLoad()
        {
            List<GenreModel> genres = db.GetGenre().Select(i => new GenreModel(i)).ToList();
            GamesList = new ObservableCollection<GameModel>(db.GetGames().Select(i => new GameModel(i, genres)).ToList());

            SelectedGame = new GameModel();
        }

        public void GenreLoad()
        {
            Genres = db.GetGenre().Select(i => new GenreModel(i)).ToList();
            SelectedGenre = new GenreModel();
        }

        public void ModeLoad()
        {
            Modes = db.GetModes().Select(i => new ModeModel(i)).ToList();
            SelectedMode = new ModeModel();
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

            PlayStorePage.NavigationService.Navigate(new InfoAboutGame(db, game, user, 1));
        }

        private RelayCommand _search;
        public RelayCommand Search
        {
            get { return _search ?? (_search = new RelayCommand(obj => SearchByCategory())); }
        }

        public void SearchByCategory()
        {
            List<GenreModel> genres = db.GetGenre().Select(i => new GenreModel(i)).ToList();

            if (SelectedGenre.Name != null && SelectedMode.Name == null)
            {
                GamesList = new ObservableCollection<GameModel>(db.GetGames()
                    .Where(i => i.GenreId == SelectedGenre.Id)
                    .Select(i => new GameModel(i, genres)));
                SelectedGenre = new GenreModel();
            }
            else if (SelectedGenre.Name == null && SelectedMode.Name != null)
            {
                GamesList = new ObservableCollection<GameModel>(db.GetGames()
                    .Where(i => i.ModeId == SelectedMode.Id)
                    .Select(i => new GameModel(i, genres)));
                SelectedMode = new ModeModel();
            }
            else if (SelectedGenre.Name != null && SelectedMode.Name != null)
            {
                GamesList = new ObservableCollection<GameModel>(db.GetGames()
                    .Where(i => i.ModeId == SelectedMode.Id && i.GenreId == SelectedGenre.Id)
                    .Select(i => new GameModel(i, genres)));
                SelectedGenre = new GenreModel();
                SelectedMode = new ModeModel();
            }
            else GamesList = new ObservableCollection<GameModel>(db.GetGames().Select(i => new GameModel(i, genres)));

            switch(SelectedItem)
            {
                case 0: { GamesList = new ObservableCollection<GameModel>(GamesList.OrderBy(i => i.Name)); break; }
                case 1: { GamesList = new ObservableCollection<GameModel>(GamesList.OrderByDescending(i => i.Rating)); break; }
                case 2: { GamesList = new ObservableCollection<GameModel>(GamesList.OrderByDescending(i => i.Price)); break; }
                case 3: { GamesList = new ObservableCollection<GameModel>(GamesList.OrderBy(i => i.ReleaseDate)); break; }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
