using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Age : BaseEntity
    {
        public Age()
        {
            Anketes = new List<Ankete>();
        }
        public string AgeName { get; set; }
        public virtual ICollection<Ankete> Anketes { get; set; }
    }
}
