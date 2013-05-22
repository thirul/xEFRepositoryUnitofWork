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
    public class ProductService : IProductService
    {
        /// <summary>
        ///IUnitOfWork
        /// </summary>
        private IUnitOfWork _unitOfWork = null;


        #region constructors
       
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        public ProductService()
        {
            _unitOfWork = new UnitOfWork(); // remove this when IOC applied
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region interface implementations

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetAll()
        {
            return _unitOfWork.Products.GetAll().AsEnumerable();
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="productId">The product id.</param>
        /// <returns></returns>
        public Product GetById(int productId)
        {
            return _unitOfWork.Products.GetById(productId);
        }

        /// <summary>
        /// Updates the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        public void Update(Product product)
        {
            _unitOfWork.Products.Update(product);
        }

        /// <summary>
        /// Deletes the specified product id.
        /// </summary>
        /// <param name="productId">The product id.</param>
        public void Delete(int productId)
        {
            _unitOfWork.Products.Delete(productId);
        }

        #endregion interface implementations
    }
}