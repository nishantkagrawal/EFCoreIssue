// <copyright file="CatalogGroup.cs" company="Thomson Reuters">
//     Copyright (c) Thomson Reuters. All rights reserved.
// </copyright>
// <summary></summary>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFCoreIssue.Models
{
    [Table("catalog_group")]
    public class CatalogGroup
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(name: "catalog_group_id", Order = 0)]
        public int GroupId { get; set; }

        [Column("catalog_category_id")]
        public int CatalogCategoryId { get; set; }

        [ForeignKey("CatalogCategoryId")]
        public CatalogCategory CatalogCategory { get; set; }

        [Column("group_name")]
        [Required]
        public string GroupName { get; set; }

        [Column("group_description")]
        [Required]
        public string GroupDescription { get; set; }

        [Column("shipping_date")]
        [Required]
        public DateTime ShippingDate { get; set; }

        [Column("notes")]
        public string Notes { get; set; }

        [Column("help_url")]
        public string HelpUrl { get; set; }

        [Column("attributes", TypeName = "json")]
        public string Attributes { get; set; }

        public virtual ICollection<CatalogMetadata> CatalogMetadata { get; set; }

        /// <summary>
        /// Called when [model creating].
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogGroup>(catalogGroups =>
            {
                catalogGroups.HasMany(p => p.CatalogMetadata).WithOne(g => g.CatalogGroup).OnDelete(DeleteBehavior.Restrict).HasConstraintName("fk_metadata_group_group_id");
                catalogGroups.HasOne(p => p.CatalogCategory).WithMany(g => g.CatalogGroups).IsRequired();
                catalogGroups
                    .ToTable("catalog_group")
                    .HasKey(k => k.GroupId)
                    .HasName("pk_catalog_group");
                catalogGroups.ToTable("catalog_group").HasIndex(p => p.GroupName).IsUnique();
            });
        }
    }
}
