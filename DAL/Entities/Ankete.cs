using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Ankete : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public virtual ICollection<AnketeGenre> AnketeGenres { get; set; }
        public Ankete()
        {
            AnketeGenres = new List<AnketeGenre>();
        }

        public int? TimeId { get; set; }
        public virtual Time Time { get; set; }
        public int AgeId { get; set; }
        public virtual Age Age { get; set; }
    }
}
