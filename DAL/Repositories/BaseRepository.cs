using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Context;
using DAL.Entities;

namespace DAL.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        public LibraryContext context;
        public BaseRepository(LibraryContext context)
        {
            this.context = context;
        }
        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public List<TEntity> Get()
        {
            return context.Set<TEntity>().ToList();
        }

        public TEntity Get(int id)
        {
            return context.Set<TEntity>().Where(x => x.Id == id).FirstOrDefault();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
