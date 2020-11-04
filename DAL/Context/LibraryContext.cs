using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Entities;

namespace DAL.Context
{
    public class LibraryContext : DbContext
    {
        public virtual DbSet<Age> Ages { get; set; }
        public virtual DbSet<Ankete> Anketes { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Time> Times { get; set; }
        public virtual DbSet<AnketeGenre> AnketeGenres { get; set; }

        public LibraryContext() : base("DBConnection")
        {

        }
    }
}
