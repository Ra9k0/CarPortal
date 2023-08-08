
using CarPortal.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarPortal.Data.Configurations
{
    public class OfferEntityConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.HasData(SeedOffers());
        }

        private Offer[] SeedOffers()
        {
            ICollection<Offer> offers = new HashSet<Offer>();

            Offer offer;

            offer = new Offer()
            {
                Id = Guid.Parse("ECC6F335-D9D0-4A1B-BB97-3A8E44FFE3AA"),
                CarId = 1,
                Price = 20000,
                Description = "Experience the epitome of automotive innovation with our brand new car. With its captivating design, advanced technology, " +
                              "and unparalleled performance, this vehicle sets new standards in the world of automobiles. Get ready to embark on a thrilling " +
                              "journey like never before.",
                OwnerId = Guid.Parse("3BA0E94F-D15F-4911-9BD0-E10E9D89397F"),
                Title = "Test1",
            };
            offers.Add(offer);

            offer = new Offer()
            {
                Id = Guid.Parse("A754B9A5-01B2-4661-BEE3-EAF37E717C36"),
                CarId = 2,
                Price = 2000,
                Description = "Experience the epitome of automotive innovation with our brand new car. With its captivating design, advanced technology, " +
                              "and unparalleled performance, this vehicle sets new standards in the world of automobiles. Get ready to embark on a thrilling " +
                              "journey like never before.",
                OwnerId = Guid.Parse("3BA0E94F-D15F-4911-9BD0-E10E9D89397F"),
                Title = "Test2"
            };
            offers.Add(offer);

            offer = new Offer()
            {
                Id = Guid.Parse("87745040-AAF7-426E-A211-D86D80085213"),
                CarId = 3,
                Price = 200,
                Description = "Experience the epitome of automotive innovation with our brand new car. With its captivating design, advanced technology, " +
                              "and unparalleled performance, this vehicle sets new standards in the world of automobiles. Get ready to embark on a thrilling " +
                              "journey like never before.",
                OwnerId = Guid.Parse("3BA0E94F-D15F-4911-9BD0-E10E9D89397F"),
                Title = "Test3"
            };
            offers.Add(offer);

            return offers.ToArray();
        }
    }
}
