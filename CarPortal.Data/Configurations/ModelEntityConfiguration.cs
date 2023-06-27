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
    public class ModelEntityConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            throw new NotImplementedException();
        }

        private Model[] seedModels()
        {
            ICollection<Model> models = new HashSet<Model>();

            Model model;

            //Alfa Romeo---------------------
            model = new Model()
            {
                Id = 1,
                Name = "Giulia Quadrifoglio",
                CategoryId = 1,
                MakeId = 2
            };
            models.Add(model);

            model = new Model()
            {
                Id = 2,
                Name = "155 Q4",
                CategoryId = 1,
                MakeId = 2
            };
            models.Add(model);

            model = new Model()
            {
                Id = 3,
                Name = "159",
                CategoryId = 1,
                MakeId = 2
            };
            models.Add(model);

            //Aston Martin---------------------
            model = new Model()
            {
                Id = 4,
                Name = "DBS Volante",
                CategoryId = 1,
                MakeId = 3
            };
            models.Add(model);

            model = new Model()
            {
                Id = 5,
                Name = "DB11",
                CategoryId = 1,
                MakeId = 3
            };
            models.Add(model);

            //Audi---------------------
            model = new Model()
            {
                Id = 6,
                Name = "TT",
                CategoryId = 1,
                MakeId = 4
            };
            models.Add(model);

            model = new Model()
            {
                Id = 7,
                Name = "Q7",
                CategoryId = 2,
                MakeId = 4
            };
            models.Add(model);

            model = new Model()
            {
                Id = 8,
                Name = "Q8",
                CategoryId = 2,
                MakeId = 4
            };
            models.Add(model);

            model = new Model()
            {
                Id = 9,
                Name = "A3",
                CategoryId = 1,
                MakeId = 4
            };
            models.Add(model);

            model = new Model()
            {
                Id = 10,
                Name = "A4",
                CategoryId = 1,
                MakeId = 4
            };
            models.Add(model);

            model = new Model()
            {
                Id = 11,
                Name = "A6",
                CategoryId = 1,
                MakeId = 4
            };
            models.Add(model);

            model = new Model()
            {
                Id = 12,
                Name = "S3",
                CategoryId = 1,
                MakeId = 4
            };
            models.Add(model);

            model = new Model()
            {
                Id = 13,
                Name = "S4",
                CategoryId = 1,
                MakeId = 4
            };
            models.Add(model);

            model = new Model()
            {
                Id = 14,
                Name = "S6",
                CategoryId = 1,
                MakeId = 4
            };
            models.Add(model);

            model = new Model()
            {
                Id = 15,
                Name = "RS3",
                CategoryId = 1,
                MakeId = 4
            };
            models.Add(model);

            model = new Model()
            {
                Id = 16,
                Name = "RS4",
                CategoryId = 1,
                MakeId = 4
            };
            models.Add(model);

            model = new Model()
            {
                Id = 17,
                Name = "RS6",
                CategoryId = 1,
                MakeId = 4
            };
            models.Add(model);

            //Bentley---------------------
            model = new Model()
            {
                Id = 18,
                Name = "Continental GT",
                CategoryId = 1,
                MakeId = 5
            };
            models.Add(model);

            model = new Model()
            {
                Id = 19,
                Name = "Mulsanne",
                CategoryId = 1,
                MakeId = 5
            };
            models.Add(model);

            //BMW---------------------
            model = new Model()
            {
                Id = 20,
                Name = "M2",
                CategoryId = 1,
                MakeId = 6
            };
            models.Add(model);

            model = new Model()
            {
                Id = 21,
                Name = "M3",
                CategoryId = 1,
                MakeId = 6
            };
            models.Add(model);

            model = new Model()
            {
                Id = 22,
                Name = "M4",
                CategoryId = 1,
                MakeId = 6
            };
            models.Add(model);

            model = new Model()
            {
                Id = 23,
                Name = "M5",
                CategoryId = 1,
                MakeId = 6
            };
            models.Add(model);

            model = new Model()
            {
                Id = 24,
                Name = "M6",
                CategoryId = 1,
                MakeId = 6
            };
            models.Add(model);

            model = new Model()
            {
                Id = 25,
                Name = "M8",
                CategoryId = 1,
                MakeId = 6
            };
            models.Add(model);

            model = new Model()
            {
                Id = 26,
                Name = "X1",
                CategoryId = 2,
                MakeId = 6
            };
            models.Add(model);

            model = new Model()
            {
                Id = 27,
                Name = "X2",
                CategoryId = 2,
                MakeId = 6
            };
            models.Add(model);

            model = new Model()
            {
                Id = 28,
                Name = "X3",
                CategoryId = 2,
                MakeId = 6
            };
            models.Add(model);

            model = new Model()
            {
                Id = 29,
                Name = "X4",
                CategoryId = 2,
                MakeId = 6
            };
            models.Add(model);

            model = new Model()
            {
                Id = 30,
                Name = "X5",
                CategoryId = 2,
                MakeId = 6
            };
            models.Add(model);

            model = new Model()
            {
                Id = 31,
                Name = "X6",
                CategoryId = 2,
                MakeId = 6
            };
            models.Add(model);

            model = new Model()
            {
                Id = 32,
                Name = "X7",
                CategoryId = 2,
                MakeId = 6
            };
            models.Add(model);

            //Citroen---------------------
            model = new Model()
            {
                Id = 33,
                Name = "",
                CategoryId = 1,
                MakeId = 7
            };
            models.Add(model);

            return models.ToArray();
        }
    }
}
