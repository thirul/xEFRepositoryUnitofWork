#region Usings


using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using xEFRepositoryUnitofWork.Data.Configuration;
using xEFRepositoryUnitofWork.Domain;

#endregion
namespace xEFRepositoryUnitofWork.Data
{
    /// <summary>
    /// EFContext
    /// </summary>
    public class EFContext:DbContext
    {
        #region Memebers


        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>
        /// The products.
        /// </value>
        public DbSet<Product> Products { get; set; }
        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        /// <value>
        /// The categories.
        /// </value>
        public DbSet<Category> Categories { get; set; }

        #endregion
        /// <summary>
        /// Initializes a new instance of the <see cref="EFContext"/> class.
        /// </summary>
        public EFContext():base("EFConnectonString")
        {
        }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
           modelBuilder.Configurations.Add(new ProductConfiguration());
           modelBuilder.Configurations.Add(new CategoryConfiguration());
        }
    }
}
