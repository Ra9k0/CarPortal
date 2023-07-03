using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarPortal.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarPortal.Data.Configurations
{
    public class ConditionEntityConfiguration : IEntityTypeConfiguration<Condition>
    {
        public void Configure(EntityTypeBuilder<Condition> builder)
        {
            builder.HasData(SeedConditions());
        }

        private Condition[] SeedConditions()
        {
            ICollection<Condition> conditions = new HashSet<Condition>();

            Condition condition;

            condition = new Condition()
            {
                Id = 1,
                Name = "New"
            };
            conditions.Add(condition);

            condition = new Condition()
            {
                Id = 2,
                Name = "Used"
            };
            conditions.Add(condition);

            condition = new Condition()
            {
                Id = 3,
                Name = "For parts"
            };
            conditions.Add(condition);

            return conditions.ToArray();
        }
    }
}
