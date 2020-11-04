using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
   public  class ReviewDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}
