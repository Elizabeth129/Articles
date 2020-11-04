using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PL.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string GenreName { get; set; }

        public virtual ICollection<AnketeGenre> AnketeGenres { get; set; }
        public Genre()
        {
            AnketeGenres = new List<AnketeGenre>();
        }
    }
}