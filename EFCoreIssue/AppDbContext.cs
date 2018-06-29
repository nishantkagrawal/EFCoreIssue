using EFCoreIssue.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreIssue
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the catalog metadata.
        /// </summary>
        /// <value>The identity mappings.</value>
        public virtual DbSet<CatalogMetadata> CatalogMetadatadbset { get; set; }

        /// <summary>
        /// Gets or sets the Catalog Groups.
        /// </summary>
        /// <value>The identity mappings.</value>
        public virtual DbSet<CatalogGroup> CatalogGroups { get; set; }

        /// <summary>
        /// Gets or sets the .
        /// </summary>
        /// <value>The identity mappings.</value>
        public virtual DbSet<CatalogCategory> CatalogCategories { get; set; }

        /// <summary>
        /// Gets or sets the Catalog discounts.
        /// </summary>
        /// <value>The catalog discounts.</value>
        public virtual DbSet<CatalogDiscount> CatalogDiscounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CatalogMetadata.OnModelCreating(modelBuilder);
            CatalogGroup.OnModelCreating(modelBuilder);
            CatalogCategory.OnModelCreating(modelBuilder);
            CatalogDiscount.OnModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
