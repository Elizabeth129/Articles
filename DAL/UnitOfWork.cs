using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Repositories;
using DAL.Context;
using DAL.Entities;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private LibraryContext _context;
        private AgeRepository ageRepository;
        private AnketeGenreRepository anketeGenreRepository;
        private AnketeRepository anketeRepository;
        private ArticleRepository articleRepository;
        private GenreRepository genreRepository;
        private ReviewRepository reviewRepository;
        private TimeRepository timeRepository;
        public UnitOfWork()
        {
            _context = new LibraryContext();
        }
        public IRepository<Age> Age
        {
            get
            {
                if (ageRepository == null)
                {
                    ageRepository = new AgeRepository(_context);
                }
                return ageRepository;
            }
        }

        public IRepository<Ankete> Ankete
        {
            get
            {
                if (anketeRepository == null)
                {
                    anketeRepository = new AnketeRepository(_context);
                }
                return anketeRepository;
            }
        }

        public IRepository<AnketeGenre> AnketeGenre
        {
            get
            {
                if (anketeGenreRepository == null)
                {
                    anketeGenreRepository = new AnketeGenreRepository(_context);
                }
                return anketeGenreRepository;
            }
        }

        public IRepository<Article> Article
        {
            get
            {
                if (articleRepository == null)
                {
                    articleRepository = new ArticleRepository(_context);
                }
                return articleRepository;
            }
        }

        public IRepository<Genre> Genre
        {
            get
            {
                if (genreRepository == null)
                {
                    genreRepository = new GenreRepository(_context);
                }
                return genreRepository;
            }
        }
        public IRepository<Review> Review
        {
            get
            {
                if (reviewRepository == null)
                {
                    reviewRepository = new ReviewRepository(_context);
                }
                return reviewRepository;
            }
        }

        public IRepository<Time> Time
        {
            get
            {
                if (timeRepository == null)
                {
                    timeRepository = new TimeRepository(_context);
                }
                return timeRepository;
            }
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
