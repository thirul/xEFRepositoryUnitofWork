#region usings

using System.Collections.Generic;
using xEFRepositoryUnitofWork.Domain;

#endregion usings

namespace xEFRepositoryUnitofWork.Services.Contract
{
    public interface ICategoryService
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Category> GetAll();

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="categoryId">The category id.</param>
        /// <returns></returns>
        Category GetById(int categoryId);

        /// <summary>
        /// Updates the specified product.
        /// </summary>
        /// <param name="category">The category.</param>
        void Update(Category category);

        /// <summary>
        /// Deletes the specified product id.
        /// </summary>
        /// <param name="categoryId">The category id.</param>
        void Delete(int categoryId);
    }
}