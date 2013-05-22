#region Usings

using System.Data.Entity;
using System.Linq;
using xEFRepositoryUnitofWork.Data.Contract;
using xEFRepositoryUnitofWork.Domain;

#endregion Usings

namespace xEFRepositoryUnitofWork.Data
{
    /// <summary>
    /// ProductRepository
    /// </summary>
    public class ProductRepository : EFRepository<Product>, IProductRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The db context.</param>
        public ProductRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        /// <summary>
        /// Gets the active products.
        /// </summary>
        /// <returns></returns>
        public IQueryable<Product> GetActiveProducts()
        {
            return DbContext.Set<Product>().Where(p => p.Active);
        }

    }
}