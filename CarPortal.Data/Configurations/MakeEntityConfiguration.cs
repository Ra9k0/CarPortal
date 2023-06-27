using CarPortal.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarPortal.Data.Configurations
{
    public class MakeEntityConfiguration : IEntityTypeConfiguration<Make>
    {
        public void Configure(EntityTypeBuilder<Make> builder)
        {
            builder.HasData(SeedMakes());
        }

        private Make[] SeedMakes()
        {
            ICollection<Make> makes = new HashSet<Make>();

            Make make;

            make = new Make()
            {
                Id = 1,
                Name = "all"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 2,
                Name = "Alfa Romeo"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 3,
                Name = "Aston Martin"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 4,
                Name = "Audi"
            };
            makes.Add(make);
            
            make = new Make()
            {
                Id = 5,
                Name = "Bentley"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 6,
                Name = "BMW"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 7,
                Name = "Citroen"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 8,
                Name = "Dacia"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 9,
                Name = "DS"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 10,
                Name = "Ferrari"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 11,
                Name = "Fiat"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 12,
                Name = "Ford"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 13,
                Name = "Honda"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 14,
                Name = "Hyundai"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 15,
                Name = "Infiniti"
            };
            makes.Add(make);
            
            make = new Make()
            {
                Id = 16,
                Name = "Jaguar"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 17,
                Name = "Jeep"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 18,
                Name = "Kia"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 19,
                Name = "Lamborghini"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 20,
                Name = "Land Rover"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 21,
                Name = "Lexus"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 22,
                Name = "Lotus"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 23,
                Name = "Maserati"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 24,
                Name = "Mazda"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 25,
                Name = "McLaren"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 26,
                Name = "Mercedes - Benz"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 27,
                Name = "Mini"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 28,
                Name = "Mitsubishi"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 29,
                Name = "Nissan"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 30,
                Name = "Peugeot"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 31,
                Name = "Porsche"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 32,
                Name = "Renault"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 33,
                Name = "Rolls - Royce"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 34,
                Name = "Seat"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 35,
                Name = "Skoda"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 36,
                Name = "Skoda"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 37,
                Name = "Smart"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 38,
                Name = "Subaru"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 39,
                Name = "Suzuki"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 40,
                Name = "Tesla"
            };
            makes.Add(make);

            make = new Make()
            {
                Id = 41,
                Name = "Toyota"
            };
            makes.Add(make);


            make = new Make()
            {
                Id = 42,
                Name = "Volkswagen"
            };
            makes.Add(make);


            return makes.ToArray();
        }
    }
}
