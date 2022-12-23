using BLL.Interfaces;
using BLL.Util;
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
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            var kernel = new StandardKernel(new NinjectRegistrations(), new ServiceModule("GamingPlatform"));
            IDbCrud crudServ = kernel.Get<IDbCrud>();

            InitializeComponent();


            AuthorizationWindowViewModel aw = new AuthorizationWindowViewModel(crudServ);
            DataContext = aw;

            if (aw.CloseAction == null)
                aw.CloseAction = new Action(this.Close);

        }
    }
}
