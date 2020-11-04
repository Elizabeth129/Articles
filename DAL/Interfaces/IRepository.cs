using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<TEntity>
    {
        List<TEntity> Get();
        TEntity Get(int id);
        void Add(TEntity entity);
        void SaveChanges();
    }
}
