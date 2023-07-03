using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarPortal.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarPortal.Data.Configurations
{
    public class EngineTypeEntityConfiguration : IEntityTypeConfiguration<EngineType>
    {
        public void Configure(EntityTypeBuilder<EngineType> builder)
        {
            builder.HasData(SeedEngineTypes());
        }

        private EngineType[] SeedEngineTypes()
        {
            ICollection<EngineType> engineTypes = new HashSet<EngineType>();

            EngineType engineType;

            engineType = new EngineType()
            {
                Id = 1,
                Type = "Petrol"
            };
            engineTypes.Add(engineType);

            engineType = new EngineType()
            {
                Id = 2,
                Type = "Diesel"
            };
            engineTypes.Add(engineType);

            engineType = new EngineType()
            {
                Id = 3,
                Type = "Electric"
            };
            engineTypes.Add(engineType);

            engineType = new EngineType()
            {
                Id = 4,
                Type = "Hybrid"
            };
            engineTypes.Add(engineType);

            return engineTypes.ToArray();
        }
    }
}
