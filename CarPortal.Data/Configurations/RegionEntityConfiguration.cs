
using CarPortal.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarPortal.Data.Configurations
{
    public class RegionEntityConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.HasData(SeedRegions());
        }

        private Region[] SeedRegions()
        {
            ICollection<Region> regions = new HashSet<Region>();

            List<string> regionNames = new List<string>()
            {
                "Blagoevgrad", "Burgas", "Dobrich", "Gabrovo", "Grad Sofia", "Khaskoro",
                "Kurdzhali", "Kyustendil", "Lovech", "Montana", "Pazardzhik", "Pernik",
                "Pleven", "Plovdiv", "Razgrad", "Ruse", "Shumen", "Silistra", "Sliven",
                "Smolyan", "Sofia", "Stara Zagora", "Turgorishte", "Varna", "Veliko Turnovo",
                "Vidin", "Vratsa", "Yambol"
            };

            for (int i = 0; i < regionNames.Count; i++)
            {
                string name = regionNames[i];
                int id = i + 1;

                Region region = new Region()
                {
                    Id = id,
                    Name = name
                };

                regions.Add(region);
            }
            return regions.ToArray();
        }
    }
}
