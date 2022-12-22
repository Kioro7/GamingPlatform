using BLL.Interfaces;
using GamingPlatform.Models;
using GamingPlatform.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GamingPlatform
{
    /// <summary>
    /// Логика взаимодействия для InfoAboutGame.xaml
    /// </summary>
    public partial class InfoAboutGame : Page
    {
        public InfoAboutGame(IDbCrud dbCrud, GameModel game, UserModel user, int pointer)
        {
            InitializeComponent();
            DataContext = new InfoAboutGameViewModel(dbCrud, game, user, this, pointer);
        }
    }
}
