using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using CarPortal.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarPortal.Data.Configurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(SeedUser());
        }

        private ApplicationUser SeedUser()
        {
            var user = new ApplicationUser()
            {
                Id = Guid.Parse("3BA0E94F-D15F-4911-9BD0-E10E9D89397F"),
                Email = "ceca@lepa.sr",
                NormalizedEmail = "CECA@LEPA.SR",
                UserName = "ceca@lepa.sr",
                NormalizedUserName = "CECA@LEPA.SR",
                RegionId = 1,
                FirstName = "Ceca",
                LastName = "Lepa"
            };

            return user;
        }
    }
}
