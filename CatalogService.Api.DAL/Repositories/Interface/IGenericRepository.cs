using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IList<TEntity> GetAll();
        TEntity GetById(int id);
        void Insert(TEntity entity, bool saveChanges = false);
        void Delete(TEntity entity, bool saveChanges = false);
        void Update(TEntity entity, bool saveChanges = false);
    }
}
