using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Time : BaseEntity
    {
        public string TimeName { get; set; }
        public virtual ICollection<Ankete> Anketes { get; set; }
        public Time()
        {
            Anketes = new List<Ankete>();
        }
    }
}
