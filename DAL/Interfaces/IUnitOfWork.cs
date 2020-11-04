using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Age> Age { get; }
        IRepository<Ankete> Ankete { get; }
        IRepository<AnketeGenre> AnketeGenre { get; }
        IRepository<Article> Article { get; }
        IRepository<Genre> Genre { get; }
        IRepository<Review> Review { get; }
        IRepository<Time> Time { get; }
        void SaveChanges();
    }
}
