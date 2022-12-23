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
    public class AuthorizationWindowViewModel : INotifyPropertyChanged
    {
        IDbCrud db;

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

        public Action CloseAction { get; set; }

        public AuthorizationWindowViewModel(IDbCrud db)
        {
            this.db = db;

            User = new UserModel();
            User = db.GetUsers().Where(i => i.Id == 2).Select(i => new UserModel(i)).FirstOrDefault();
            GLOBAL.User = User;
        }

        private RelayCommand _click;
        public RelayCommand Click
        {
            get { return _click ?? (_click = new RelayCommand(obj => Authorization())); }
        }

        public void Authorization()
        {
            MainWindow main = new MainWindow();
            main.Show();

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
