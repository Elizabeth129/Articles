using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PL.Models;

namespace PL.ViewModel
{
    public class ArticleIndex
    {
        public IEnumerable<Article> Articles { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}