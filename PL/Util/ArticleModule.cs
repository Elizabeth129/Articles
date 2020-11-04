using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using BLL.Interfaces;
using BLL.Services;

namespace PL.Util
{
    public class ArticleModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IArticleService>().To<ArticleService>();
        }

    }
}