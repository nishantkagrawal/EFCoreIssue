using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreIssue.Models
{
    public class CatalogDiscount
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(name: "catalog_discount_id", Order = 0)]
        public int Id { get; set; }

        [Column("order_quantity")]
        [Required]
        public string OrderQuantity { get; set; }

        [Column("discount")]
        [Required]
        public int Discount { get; set; }

        [Column("notes")]
        public string Notes { get; set; }

        [Column(name: "start_date")]
        [Required]
        public DateTime StartDate { get; set; }

        [Column(name: "end_date")]
        [Required]
        public DateTime EndDate { get; set; }

        [Column(name: "catalog_category_id")]
        public int CatalogCategoryId { get; set; }

        [ForeignKey("CatalogCategoryId")]
        public CatalogCategory CatalogCategory { get; set; }

        [Column("free_shipping")]
        [Required]
        public bool FreeShipping { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogDiscount>(catalogDiscount =>
            {
                catalogDiscount.HasOne(p => p.CatalogCategory).WithMany(g => g.CatalogDiscounts).IsRequired();
                catalogDiscount
                    .ToTable("catalog_discount")
                    .HasKey(k => k.Id)
                    .HasName("pk_catalog_discount");
            });
        }
    }


}
