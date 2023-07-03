
using CarPortal.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarPortal.Data.Configurations
{
    public class ImageEntityConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasData(SeedImages());
        }

        private Image[] SeedImages()
        {
            var images = new HashSet<Image>();

            Image image;

            image = new Image()
            {
                Id = 1,
                OfferId = Guid.Parse("ECC6F335-D9D0-4A1B-BB97-3A8E44FFE3AA"),
                PhotoPath = "OfferImages/test1.jpeg"
            };
            images.Add(image);

            image = new Image()
            {
                Id = 2,
                OfferId = Guid.Parse("A754B9A5-01B2-4661-BEE3-EAF37E717C36"),
                PhotoPath = "OfferImages/test2.jpg"
            };
            images.Add(image);

            image = new Image()
            {
                Id = 3,
                OfferId = Guid.Parse("87745040-AAF7-426E-A211-D86D80085213"),
                PhotoPath = "OfferImages/test3.jpg"
            };
            images.Add(image);

            return images.ToArray();
        }
    }
}
