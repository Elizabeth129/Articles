using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Genre : BaseEntity
    {
        public string GenreName { get; set; }

        public virtual ICollection<AnketeGenre> AnketeGenres { get; set; }
        public Genre()
        {
            AnketeGenres = new List<AnketeGenre>();
        }
    }
}
