using EFCoreIssue.Models;
using EFCoreIssue.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace EFCoreIssue.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void VerifyCatalogGroupDelete_Throws_InvalidOperationException_When_There_Are_Dependencies()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase("delete_cataloggroup_invalidoperationexception").Options;

            using (var context = new AppDbContext(options))
            {
                var repository = new CatalogMetadataRepository(context);

                CatalogMetadata metadata = repository.CreateCatalogMetadata(new CatalogMetadata()
                {
                    ProductCode = "testProductCode",
                    Description = "testProductDescription",
                    Title = "testTitle",
                    CatalogGroup = new CatalogGroup()
                    {
                        GroupName = "testGroupName",
                        GroupDescription = "testGroupDescription",
                        CatalogCategory = new CatalogCategory()
                        {
                            CategoryId = 1,
                            CategoryName = "testCategoryName",
                        },
                    },
                });

                Assert.True(metadata.CatalogGroupId > 0);

                Assert.Throws<InvalidOperationException>(() => repository.DeleteCatalogGroup(metadata.CatalogGroupId));
            }
        }
    }
}
