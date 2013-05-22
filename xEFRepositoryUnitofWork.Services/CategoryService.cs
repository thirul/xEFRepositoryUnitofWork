#region usings

using System.Linq;

#endregion usings

using System.Collections.Generic;
using xEFRepositoryUnitofWork.Data;
using xEFRepositoryUnitofWork.Data.Contract;
using xEFRepositoryUnitofWork.Domain;
using xEFRepositoryUnitofWork.Services.Contract;

namespace xEFRepositoryUnitofWork.Services
{
    /// <summary>
    /// ProductService
    /// </summary>
    public class CategoryService : ICategoryService
    {
        /// <summary>
        /// IUnitOfWork
        /// </summary>
        private IUnitOfWork _unitOfWork = null;


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryService"/> class.
        /// </summary>
        public CategoryService()
        {
            _unitOfWork = new UnitOfWork(); // remove this when IOC applied
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion


        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Category> GetAll()
        {
            return _unitOfWork.Categories.GetAll().AsEnumerable();
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="categoryId">The category id.</param>
        /// <returns></returns>
        public Category GetById(int categoryId)
        {
            return _unitOfWork.Categories.GetById(categoryId);
        }

        /// <summary>
        /// Updates the specified product.
        /// </summary>
        /// <param name="category">The category.</param>
        public void Update(Category category)
        {
            _unitOfWork.Categories.Update(category);
        }

        /// <summary>
        /// Deletes the specified product id.
        /// </summary>
        /// <param name="categoryId">The category id.</param>
        public void Delete(int categoryId)
        {
            _unitOfWork.Categories.Delete(categoryId);
        }
    }
}