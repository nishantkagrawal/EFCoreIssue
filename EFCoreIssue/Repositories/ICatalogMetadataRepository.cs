using EFCoreIssue.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCoreIssue.Repositories
{
    public interface ICatalogMetadataRepository
    {
        CatalogMetadata CreateCatalogMetadata(CatalogMetadata entity);

        CatalogMetadata UpdateCatalogMetadata(CatalogMetadata updatedEntity);

        bool DeleteCatalogMetadata(int id);

        CatalogCategory CreateCatalogCategory(CatalogCategory entity);

        CatalogCategory UpdateCatalogCategory(CatalogCategory updatedEntity);

        bool DeleteCatalogCategory(int id);

        CatalogGroup CreateCatalogGroup(CatalogGroup entity);

        CatalogGroup UpdateCatalogGroup(CatalogGroup updatedEntity);

        bool DeleteCatalogGroup(int id);

        CatalogDiscount CreateCatalogDiscount(CatalogDiscount entity);

        CatalogDiscount UpdateCatalogDiscount(CatalogDiscount updatedEntity);

        bool DeleteCatalogDiscount(int id);

        Task<IEnumerable<CatalogMetadata>> GetAllCatalogMetadata();

        Task<IEnumerable<CatalogDiscount>> GetAllCatalogDiscountsAsync();

        Task<IEnumerable<CatalogGroup>> GetAllCatalogGroupsAsync();

        Task<IEnumerable<CatalogCategory>> GetAllCatalogCategoriesAsync();

        Task<IEnumerable<CatalogMetadata>> GetAllCatalogMetadataAsync();
    }
}