#region Usings

using System;
using System.Transactions;
using xEFRepositoryUnitofWork.Data.Contract;
using xEFRepositoryUnitofWork.Domain;

#endregion Usings

namespace xEFRepositoryUnitofWork.Data
{
    /// <summary>
    /// UnitOfWork class
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Members

        /// <summary>
        /// Gets or sets the db context.
        /// </summary>
        /// <value>
        /// The db context.
        /// </value>
        private EFContext DbContext { get; set; }

        /// <summary>
        /// _beginTransaction
        /// </summary>
        private bool _beginTransaction = false;

        /// <summary>
        /// disposed
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// Gets the products.
        /// </summary>
        public IProductRepository Products { get { return new ProductRepository(this.DbContext); } }

        /// <summary>
        /// Gets the categories.
        /// </summary>
        public IRepository<Category> Categories { get { return GetGenericRepository<Category>(); } }

        #endregion Members

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        public UnitOfWork()
        {
            CreateDbContext();
        }

        /// <summary>
        /// Creates the db context.
        /// </summary>
        protected void CreateDbContext()
        {
            DbContext = new EFContext();
        }

        #region public methods

        /// <summary>
        /// Commits this instance.
        /// </summary>
        public void Commit()
        {
            if (_beginTransaction)
            {
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    try
                    {
                        DbContext.SaveChanges();
                        transactionScope.Complete();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    _beginTransaction = false;
                }
            }
            else
            {
                DbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    DbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Begins the transaction.
        /// </summary>
        public void BeginTransaction()
        {
            _beginTransaction = true;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion public methods


        #region private methods
        private IRepository<T> GetGenericRepository<T>() where T : class
        {
            return new EFRepository<T>(this.DbContext);
        }
        #endregion
    }
}