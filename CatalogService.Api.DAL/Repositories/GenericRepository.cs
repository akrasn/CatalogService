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

        public void Delete(TEntity entity)
        {
            //this.DbSet.Attach(entity);
                    var entityContext = Context.Entry(entity);
            entityContext.State = EntityState.Detached;
            Context.SaveChanges();
            //this.DbSet.Attach(entity);
            //entityContext.State = EntityState.Modified;
            this.DbSet.Remove(entity);
            Context.SaveChanges();
        }

        public void Insert(TEntity entity)
        {
            this.DbSet.Add(entity);
            Context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            var entityContext = Context.Entry(entity);
            this.DbSet.Attach(entity);
            entityContext.State = EntityState.Modified;
            Context.SaveChanges();

        }
    }
}
