using BLL.Interfaces;
using GamingPlatform.Models;
using GamingPlatform.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace GamingPlatform.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        IDbCrud db;
        private Page home;
        private Page playStore;
        private Page list;
        private Page userPage;

        private UserModel user;
        public UserModel User 
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        private int _selectedTabItem;
        public int SelectedTabItem 
        {
            get 
            { 
                if (_selectedTabItem != -1)
                    SwitchPage(_selectedTabItem);
                return _selectedTabItem; 
            }
            set { _selectedTabItem = value; }
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

        public void SwitchPage(int obj)
        {
            switch(obj)
            {
                case 0: { home = new Home(); CurrentPage = home; break; }
                case 1: { playStore = new PlayStore(); CurrentPage = playStore; break; }
                case 2: { list = new GameList(User); CurrentPage = list; break; }
            }
        }

        private RelayCommand _clickCommand;

        public MainWindowViewModel(IDbCrud db)
        {
            this.db = db;

            GLOBAL.User = db.GetUsers().Where(i => i.Id == 2).Select(i => new UserModel(i)).FirstOrDefault();

            User = GLOBAL.User;

            home = new Home();
            playStore = new PlayStore();
            list = new GameList(User);
            userPage = new UserPage();

            SelectedTabItem = 0;
            CurrentPage = home;
        }

        public RelayCommand ClickCommand
        {
            get { return _clickCommand ?? (_clickCommand = new RelayCommand(obj => SwitchUserPage())); }
        }

        public void SwitchUserPage()
        {
            CurrentPage = userPage;
        }

        private RelayCommand _changeBalance;
        public RelayCommand ChangeBalance
        {
            get { return _changeBalance ?? (_changeBalance = new RelayCommand(obj => Changes())); }
        }

        public void Changes()
        {
            User = GLOBAL.User;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
