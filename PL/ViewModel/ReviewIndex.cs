using PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PL.ViewModel
{
    public class ReviewIndex
    {
        public IEnumerable<Review> Reviews { get; set; }
        public Review ReviewNew { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}