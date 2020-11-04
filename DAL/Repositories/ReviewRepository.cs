using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Context;

namespace DAL.Repositories
{
    public class ReviewRepository : BaseRepository<Review>
    {
        public ReviewRepository(LibraryContext context) : base(context) { }
    }
}
