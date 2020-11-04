using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class AnketeGenre : BaseEntity
    {
        public int GenreId { get; set; }
        public int AnketeId { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Ankete Ankete { get; set; }
    }
}
