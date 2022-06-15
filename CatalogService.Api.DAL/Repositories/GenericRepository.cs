using DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        // Instance of the DbContext. Must be passed or injected.        
        private StoreDataContext Context { get; set; }
        public GenericRepository(StoreDataContext context)
        {
            Context = context;
        }

        //Internally re-usable DbSet instance.
        protected DbSet<TEntity> DbSet
        {
            get
            {
                if (_dbSet == null)
                    _dbSet = Context.Set<TEntity>();
                return _dbSet;
            }
        }
        private DbSet<TEntity> _dbSet;


        public virtual IList<TEntity> GetAll()
        {
            return this.DbSet.ToList();
        }
        public virtual TEntity GetById(int id)
        {
            return this.DbSet.Find(id);
        }

        public void Delete(TEntity entity, bool saveChanges = false)
        {
            this.DbSet.Attach(entity);
            this.DbSet.Remove(entity);
            if (saveChanges)
            {
                Context.SaveChanges();
            }
        }

        public void Insert(TEntity entity, bool saveChanges = false)
        {
            this.DbSet.Add(entity);
            if (saveChanges)
            {
                Context.SaveChanges();
            }
        }

        public void Update(TEntity entity, bool saveChanges = false)
        {
            var entry = Context.Entry(entity);
            this.DbSet.Attach(entity);
            entry.State = EntityState.Modified;
            if (saveChanges)
            {
                Context.SaveChanges();
            }
        }
    }
}
