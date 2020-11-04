using DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Repositories
{
    public class AgeRepository : BaseRepository<Age>
    {
        public AgeRepository(LibraryContext context) : base(context) { }

    }
}
