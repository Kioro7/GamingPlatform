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
    public class UserPageViewModel : INotifyPropertyChanged
    {
        IDbCrud db;
        public UserModel User { get; set; }

        public UserPageViewModel(IDbCrud db)
        {
            this.db = db;

            User = db.GetUsers().Where(i => i.Id == 2).Select(i => new UserModel(i)).FirstOrDefault();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
