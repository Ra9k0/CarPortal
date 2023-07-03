using CarPortal.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarPortal.Data.Configurations
{
    public class ColorEntityConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasData(SeedColors());
        }

        private Color[] SeedColors()
        {
            ICollection<Color> carColors = new HashSet<Color>();

            List<string> colorNames = new List<string>()
            {
                "Black", "White", "Silver", "Gray", "Red", "Blue", "Brown", "Green", "Yellow", "Orange",
                "Purple", "Pink", "Gold", "Beige", "Bronze", "Copper", "Maroon", "Navy", "Turquoise", "Teal"
            };

            for (int i = 0; i < colorNames.Count; i++)
            {
                string name = colorNames[i];
                int id = i + 1;

                Color color = new Color()
                {
                    Id = id,
                    Name = name
                };

                carColors.Add(color);
            }

            return carColors.ToArray();
        }
    }
}
