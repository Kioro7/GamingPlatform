using BLL.Interfaces;
using BLL;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services;

namespace GamingPlatform.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IDbCrud>().To<DbDataOperation>();
            Bind<IPurchaseService>().To<PurchaseService>();
        }
    }
}
