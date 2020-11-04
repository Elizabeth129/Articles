using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PL.Models
{
    public class AnketeGenre
    {
        public int Id { get; set; }
        public int GenreId { get; set; }
        public int AnketeId { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Ankete Ankete { get; set; }
    }
}