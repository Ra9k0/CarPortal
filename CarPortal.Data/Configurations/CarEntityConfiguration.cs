using CarPortal.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarPortal.Data.Configurations
{
    public class CarEntityConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasData(SeedCars());
        }

        private Car[] SeedCars()
        {
            ICollection<Car> cars = new HashSet<Car>();

            Car car;

            car = new Car()
            {
                Id = 1,
                ColorId = 1,
                EngineTypeId = 1,
                ManufactureYear = 2021,
                ModelId = 1,
                ConditionId = 1,
            };
            cars.Add(car);

            car = new Car()
            {
                Id = 2,
                ColorId = 5,
                EngineTypeId = 2,
                ManufactureYear = 2006,
                ModelId = 6,
                ConditionId = 2,
            };
            cars.Add(car);

            car = new Car()
            {
                Id = 3,
                ColorId = 3,
                EngineTypeId = 3,
                ManufactureYear = 2000,
                ModelId = 3,
                ConditionId = 3,
            };
            cars.Add(car);

            return cars.ToArray();
        }
    }
}
