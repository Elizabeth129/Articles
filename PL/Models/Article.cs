using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PL.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Headline { get; set; }
        public string Text { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}