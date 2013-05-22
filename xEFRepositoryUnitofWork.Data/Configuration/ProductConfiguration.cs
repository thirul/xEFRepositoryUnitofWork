using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using xEFRepositoryUnitofWork.Domain;

namespace xEFRepositoryUnitofWork.Data
{
    public class ProductConfiguration: EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            HasKey(s => s.ProductId).Property(p => p.ProductId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }

    }
}
