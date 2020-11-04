using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Article : BaseEntity
    {
        public string Headline { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
