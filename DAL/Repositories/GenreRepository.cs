using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Context;

namespace DAL.Repositories
{
    public class GenreRepository : BaseRepository<Genre>
    {
        public GenreRepository(LibraryContext context) : base(context) { }
    }
}
