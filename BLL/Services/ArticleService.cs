using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Interfaces;
using BLL.DTO;
using AutoMapper;
using DAL.Entities;

namespace BLL.Services
{
    public class ArticleService : IArticleService
    {
        IUnitOfWork Database { get; set; }

        public ArticleService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public IEnumerable<ArticleDTO> GetAllArticles()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Article, ArticleDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Article>, List<ArticleDTO>>(Database.Article.Get());
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
