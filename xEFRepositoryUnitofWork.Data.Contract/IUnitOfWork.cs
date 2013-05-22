#region usings

using xEFRepositoryUnitofWork.Domain;

#endregion usings

namespace xEFRepositoryUnitofWork.Data.Contract
{
    /// <summary>
    /// IUnitoOfwork
    /// </summary>
    public interface IUnitOfWork
    {
        #region memebers

        /// <summary>
        /// Gets the products.
        /// </summary>
        IRepository<Product> Products { get; }

        /// <summary>
        /// Gets the categories.
        /// </summary>
        IRepository<Category> Categories { get; }

        #endregion memebers

        #region methods

        /// <summary>
        /// Begins the transaction.
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Commits this instance.
        /// </summary>
        void Commit();

        #endregion methods
    }
}