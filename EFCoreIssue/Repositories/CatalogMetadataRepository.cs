using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EFCoreIssue.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace EFCoreIssue.Repositories
{
    public class CatalogMetadataRepository : ICatalogMetadataRepository
    {
        private readonly AppDbContext context;

        public CatalogMetadataRepository(AppDbContext context)
        {
            this.context = context;
        }     

        public async Task<IEnumerable<CatalogMetadata>> GetAllCatalogMetadata()
        {
            var details = this.context.CatalogMetadatadbset.Include(c => c.CatalogGroup).ThenInclude(cg => cg.CatalogCategory).ToList();
            return await Task.FromResult(details).ConfigureAwait(false);
        }

        public CatalogMetadata CreateCatalogMetadata(CatalogMetadata entity)
        {
            this.context.CatalogMetadatadbset.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public CatalogMetadata UpdateCatalogMetadata(CatalogMetadata updatedEntity)
        {
            var existingObj = this.context.CatalogMetadatadbset.Where(p => p.Id == updatedEntity.Id).FirstOrDefault();
            if (existingObj == null)
            {
                throw new RowNotInTableException("row not found with the given entity id ");
            }

            this.context.Entry(existingObj).CurrentValues.SetValues(updatedEntity);
            this.context.SaveChanges();
            return updatedEntity;
        }

        public bool DeleteCatalogMetadata(int id)
        {
            var existingfeature = this.context.CatalogMetadatadbset.Where(p => p.Id == id).FirstOrDefault();

            if (existingfeature != null)
            {
                this.context.CatalogMetadatadbset.Remove(existingfeature);
                this.context.SaveChanges();
                return true;
            }

            return false;
        }

        public CatalogCategory CreateCatalogCategory(CatalogCategory entity)
        {
            this.context.CatalogCategories.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public CatalogCategory UpdateCatalogCategory(CatalogCategory updatedEntity)
        {
            var existingObj = this.context.CatalogCategories.Where(p => p.CategoryId == updatedEntity.CategoryId).FirstOrDefault();
            this.context.Entry(existingObj).CurrentValues.SetValues(updatedEntity);
            this.context.SaveChanges();
            return updatedEntity;
        }

        public bool DeleteCatalogCategory(int id)
        {
            var existingfeature = this.context.CatalogCategories.Where(p => p.CategoryId == id).FirstOrDefault();

            if (existingfeature != null)
            {
                this.context.CatalogCategories.Remove(existingfeature);
                this.context.SaveChanges();
                return true;
            }

            return false;
        }

        public CatalogGroup CreateCatalogGroup(CatalogGroup entity)
        {
            this.context.CatalogGroups.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public CatalogGroup UpdateCatalogGroup(CatalogGroup updatedEntity)
        {
            var existingObj = this.context.CatalogGroups.Where(p => p.GroupId == updatedEntity.GroupId).FirstOrDefault();
            this.context.Entry(existingObj).CurrentValues.SetValues(updatedEntity);
            this.context.SaveChanges();
            return updatedEntity;
        }

        public bool DeleteCatalogGroup(int id)
        {
            var existingfeature = this.context.CatalogGroups.Where(p => p.GroupId == id).FirstOrDefault();

            if (existingfeature != null)
            {
                this.context.CatalogGroups.Remove(existingfeature);
                this.context.SaveChanges();
                return true;
            }
            return false;
        }

        public CatalogDiscount CreateCatalogDiscount(CatalogDiscount entity)
        {
            this.context.CatalogDiscounts.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public CatalogDiscount UpdateCatalogDiscount(CatalogDiscount updatedEntity)
        {
            var existingObj = this.context.CatalogDiscounts.Where(p => p.Id == updatedEntity.Id).FirstOrDefault();
            this.context.Entry(existingObj).CurrentValues.SetValues(updatedEntity);
            this.context.SaveChanges();
            return updatedEntity;
        }

        public bool DeleteCatalogDiscount(int id)
        {
            var existingfeature = this.context.CatalogDiscounts.Where(p => p.Id == id).FirstOrDefault();

            if (existingfeature != null)
            {
                this.context.CatalogDiscounts.Remove(existingfeature);
                this.context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<CatalogDiscount>> GetAllCatalogDiscountsAsync()
        {
            var details = this.context.CatalogDiscounts.Include(c => c.CatalogCategory).ToList();
            return await Task.FromResult(details).ConfigureAwait(false);
        }

        public async Task<IEnumerable<CatalogGroup>> GetAllCatalogGroupsAsync()
        {
            var details = this.context.CatalogGroups.Include(c => c.CatalogCategory).ToList();
            return await Task.FromResult(details).ConfigureAwait(false);
        }

        public async Task<IEnumerable<CatalogCategory>> GetAllCatalogCategoriesAsync()
        {
            var details = this.context.CatalogCategories.ToList();
            return await Task.FromResult(details).ConfigureAwait(false);
        }

        public async Task<IEnumerable<CatalogMetadata>> GetAllCatalogMetadataAsync()
        {
            var details = this.context.CatalogMetadatadbset.Include(cm => cm.CatalogGroup).ToList();
            return await Task.FromResult(details).ConfigureAwait(false);
        }
    }
}