using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreIssue.Models
{
    [Table("catalog_metadata")]
    public class CatalogMetadata
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(name: "catalog_metadata_id", Order = 0)]
        public int Id { get; set; }

        [Column(name: "product_code")]
        [Required]
        public string ProductCode { get; set; }

        [Column(name: "start_date")]
        [Required]
        public DateTime StartDate { get; set; }

        [Column(name: "end_date")]
        [Required]
        public DateTime EndDate { get; set; }

        [Column(name: "current_volume")]
        [Required]
        public string CurrentVolume { get; set; }

        [Column(name: "pre_sell_volume")]
        [Required]
        public string PreSellVolume { get; set; }

        [Column("description")]
        [Required]
        public string Description { get; set; }

        [Column("title")]
        [Required]
        public string Title { get; set; }

        [ForeignKey("CatalogGroupId")]
        public virtual CatalogGroup CatalogGroup { get; set; }

        [Column("catalog_group_id")]
        public int CatalogGroupId { get; set; }

        [Column("attributes", TypeName = "json")]
        public string Attributes { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogMetadata>(missingProductDetails =>
            {
                missingProductDetails.HasOne(p => p.CatalogGroup).WithMany(g => g.CatalogMetadata).IsRequired();
                missingProductDetails
                    .ToTable("catalog_metadata")
                    .HasKey(k => k.Id)
                    .HasName("pk_catalog_metadata");
                missingProductDetails.ToTable("catalog_metadata").HasIndex(p => p.ProductCode).IsUnique();
            });
        }
    }
}
