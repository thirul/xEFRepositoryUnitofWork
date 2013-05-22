
#region usings 

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using xEFRepositoryUnitofWork.Data.Contract;
using xEFRepositoryUnitofWork.Domain;

#endregion

namespace xEFRepositoryUnitofWork.Data
{
    /// <summary>
    /// EFRepository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EFRepository<T>: IRepository<T> where T: class
    {
        #region Members

        /// <summary>
        /// Gets or sets the db context.
        /// </summary>
        /// <value>
        /// The db context.
        /// </value>
        protected DbContext DbContext { get; set; }
        /// <summary>
        /// Gets or sets the db set.
        /// </summary>
        /// <value>
        /// The db set.
        /// </value>
        protected DbSet<T> DbSet { get; set; }

        #endregion
        
        #region consructors
        
        /// <summary>
        /// Initializes a new instance of the <see cref="EFRepository&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="dbContext">The db context.</param>
        public EFRepository(DbContext dbContext )
        {
            this.DbContext = dbContext;
            this.DbSet = this.DbContext.Set<T>();
        }
        #endregion

        #region public methods

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            return DbSet;
        }
        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Add(T entity)
        {
            var entityEntry = DbContext.Entry(entity);
            if (entityEntry.State != EntityState.Detached)
            {
                entityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
            
        }
        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Update(T entity)
        {
            var entityEntry = DbContext.Entry(entity);
            if (entityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            entityEntry.State = EntityState.Modified;
            
        }
        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Delete(T entity)
        {
            var entityEntry = DbContext.Entry(entity);
            if (entityEntry.State != EntityState.Deleted)
            {
                entityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }

        }

        /// <summary>
        /// Deletes the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        public virtual void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null)
                return;
            Delete(entity);
        }

        #endregion

    }
}
