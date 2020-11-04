using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces;
using BLL.DTO;
using AutoMapper;
using PL.Models;
using PL.ViewModel;

namespace PL.Controllers
{
    public class MainController : Controller
    {
        IArticleService articleService;
        List<Article> Articles;
        public MainController(IArticleService serv)
        {
            articleService = serv;
            IEnumerable<ArticleDTO> articless = articleService.GetAllArticles();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ArticleDTO, Article>()).CreateMapper();
            Articles = mapper.Map<IEnumerable<ArticleDTO>, List<Article>>(articless);
        }
        // GET: Main
        public ActionResult Index(int page = 1)
        {
            int pageSize = 1; 
            IEnumerable<Article> anketesPerPages = Articles.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = Articles.Count };
            ArticleIndex ivm = new ArticleIndex { PageInfo = pageInfo, Articles = anketesPerPages };
            return View(ivm);
        }
        public ActionResult AllText(int Id)
        {
            int id = Id;
            IEnumerable<ArticleDTO> articles = articleService.GetAllArticles();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ArticleDTO, Article>()).CreateMapper();
            ViewBag.Article = mapper.Map<IEnumerable<ArticleDTO>, List<Article>>(articles).Where(x => x.Id == id).Select(x => x).FirstOrDefault();
            return View("Article");
        }
        protected override void Dispose(bool disposing)
        {
            articleService.Dispose();
            base.Dispose(disposing);
        }
    }
}