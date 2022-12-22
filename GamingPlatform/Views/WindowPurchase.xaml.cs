using BLL.Interfaces;
using BLL.Util;
using GamingPlatform.Models;
using GamingPlatform.Util;
using GamingPlatform.ViewModels;
using Ninject;
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
using System.Windows.Shapes;

namespace GamingPlatform
{
    /// <summary>
    /// Логика взаимодействия для WindowPurchase.xaml
    /// </summary>
    public partial class WindowPurchase : Window
    {
        public WindowPurchase(IDbCrud dbCrud, GameModel game, UserModel user)
        {
            var kernel = new StandardKernel(new NinjectRegistrations(), new ServiceModule("GamingPlatform"));
            IPurchaseService purchServ = kernel.Get<IPurchaseService>();

            InitializeComponent();
            WindowPurchaseViewModel wpvm = new WindowPurchaseViewModel(dbCrud, purchServ, game, user);
            DataContext = wpvm;

            if (wpvm.CloseAction == null)
                wpvm.CloseAction = new Action(this.Close);
        }
    }
}
