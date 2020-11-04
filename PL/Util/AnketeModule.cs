using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using BLL.Interfaces;
using BLL.Services;

namespace PL.Util
{
    public class AnketeModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAnketeService>().To<AnketeService>();
        }
    }
}