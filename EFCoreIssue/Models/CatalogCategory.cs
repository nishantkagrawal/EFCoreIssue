using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreIssue.Models
{
    public class CatalogCategory
    {
        [Column("catalog_category_id")]
        public int CategoryId { get; set; }

        [Column("category_name")]
        [Required]
        public string CategoryName { get; set; }

        [Column("category_description")]
        public string CategoryDescription { get; set; }

        public virtual ICollection<CatalogGroup> CatalogGroups { get; set; }

        public virtual ICollection<CatalogDiscount> CatalogDiscounts { get; set; }


        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogCategory>(catalogCategories =>
            {
                catalogCategories.HasMany(p => p.CatalogGroups).WithOne(g => g.CatalogCategory).OnDelete(DeleteBehavior.Restrict).HasConstraintName("fk_group_category_category_id");
                catalogCategories.HasMany(p => p.CatalogDiscounts).WithOne(g => g.CatalogCategory).OnDelete(DeleteBehavior.Restrict).HasConstraintName("fk_discount_category_category_id");
                catalogCategories
                    .ToTable("catalog_category")
                    .HasKey(k => k.CategoryId)
                    .HasName("pk_catalog_category");
                catalogCategories.ToTable("catalog_category").HasIndex(p => p.CategoryName).IsUnique();
            });
        }
    }


}
