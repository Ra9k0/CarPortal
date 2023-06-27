using CarPortal.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarPortal.Data.Configurations
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(SeedCategories());
        }

        private Category[] SeedCategories()
        {
            ICollection<Category> categories = new HashSet<Category>();

            Category category;

            category = new Category()
            {
                Id = 1,
                Name = "Cars"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 2,
                Name = "Jeeps"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 3,
                Name = "Motors"
            };
            categories.Add(category);

            return categories.ToArray();
        }
    }
}
