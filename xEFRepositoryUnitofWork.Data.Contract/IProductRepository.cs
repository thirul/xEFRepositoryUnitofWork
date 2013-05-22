#region usings

using System.Linq;
using xEFRepositoryUnitofWork.Domain;

#endregion usings

namespace xEFRepositoryUnitofWork.Data.Contract
{
    public interface IProductRepository:IRepository<Product>
    {
        /// <summary>
        /// Gets the active products.
        /// </summary>
        /// <returns></returns>
        IQueryable<Product> GetActiveProducts();
    }
}