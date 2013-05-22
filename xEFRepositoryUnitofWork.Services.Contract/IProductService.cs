#region usings

using System.Collections.Generic;
using xEFRepositoryUnitofWork.Domain;

#endregion usings

namespace xEFRepositoryUnitofWork.Services.Contract
{
    public interface IProductService
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Product> GetAll();

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="productId">The product id.</param>
        /// <returns></returns>
        Product GetById(int productId);

        /// <summary>
        /// Updates the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        void Update(Product product);

        /// <summary>
        /// Deletes the specified product id.
        /// </summary>
        /// <param name="productId">The product id.</param>
        void Delete(int productId);
    }
}