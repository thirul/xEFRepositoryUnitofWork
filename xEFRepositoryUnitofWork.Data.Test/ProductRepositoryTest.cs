using System;
using System.Data.SqlClient;
using System.Linq;
using NUnit.Framework;
using xEFRepositoryUnitofWork.Data.Contract;
using xEFRepositoryUnitofWork.Domain;

namespace xEFRepositoryUnitofWork.Data.Test
{
    [TestFixture]
    public class ProductRepositoryTest
    {
        /// <summary>
        /// IUnitOfWork
        /// </summary>
        private IUnitOfWork _unitOfWork = null;

        /// <summary>
        /// Setups this instance.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Gets the products test.
        /// </summary>
        [Test]
        public void GetProductsTest()
        {
            var rooms = _unitOfWork.Products.GetAll();
            Assert.Greater(rooms.Count(), 0);
        }

        /// <summary>
        /// Gets the by id test.
        /// </summary>
        [Test]
        public void GetByIdTest()
        {
            var product = _unitOfWork.Products.GetById(1);
            Assert.IsNotNull(product);
            Assert.AreEqual("jQuery in Action", product.Name);
        }

        /// <summary>
        /// Adding_a_new_product_called_s the gita_book_with_category_books.
        /// </summary>
        [Test]
        public void adding_a_new_product_called_Gita_book_with_category_books()
        {
            var newBook = new Product()
                              {
                                  CategoryId = 1,
                                  Price = 12.25,
                                  Name = "Gita Makarandam",
                                  ShortDescription = "Gita descriptions ",
                                  Active = true,
                                  CreateDate = DateTime.Now,
                                  UpdateDate = null
                              };

            _unitOfWork.Products.Add((newBook));
            _unitOfWork.Commit();

            // get value
            var book = _unitOfWork.Products.GetById(100);

            Assert.NotNull(book);
            Assert.AreEqual(newBook.Name, book.Name);
        }

        /// <summary>
        /// Adding_new_category_with_transactionscope_rollbacks this instance.
        /// </summary>
        [Test]
        [ExpectedException(typeof(SqlException))]
        public void adding_new_category_with_transactionscope_rollback()
        {
            var category = new Category()
                               {
                                   // Name = "dummy2",
                                   UpdateDate = null,
                                   CreateDate = DateTime.Now,
                                   //  Active = true
                               };

            _unitOfWork.BeginTransaction();
            _unitOfWork.Categories.Add(category);
            _unitOfWork.Commit();
        }


        /// <summary>
        /// Get_product_and_modify_product_and_commit_changeses this instance.
        /// </summary>
        [Test]
        public void get_product_and_modify_product_and_commit_changes()
        {
            var product = _unitOfWork.Products.GetById(1);
            var modifiedName = product.Name + " : modified";
            product.Name = modifiedName;
            _unitOfWork.Products.Update((product));
            _unitOfWork.Commit();

            product = _unitOfWork.Products.GetById(1);
            Assert.AreEqual(product.Name, modifiedName);
        }

        [Test]
        public void delete_product_with_name_pro_mvc_from_database()
        {
            var product = _unitOfWork.Products.GetAll().Where(x => x.Name.Contains("Pro MVC ")).FirstOrDefault();
            if (product != null)
            {
                _unitOfWork.Products.Delete(product.ProductId);
                _unitOfWork.Commit();
            }
        }

        /// <summary>
        /// Tears down.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            _unitOfWork = null;
        }
    }
}