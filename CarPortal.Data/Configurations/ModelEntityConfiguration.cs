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
            builder.HasData(SeedModels());
        }

        private Model[] SeedModels()
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
                Name = "C1",
                CategoryId = 1,
                MakeId = 7,
            };
            models.Add(model);

            model = new Model()
            {
                Id = 34,
                Name = "C2",
                CategoryId = 1,
                MakeId = 7,
            };
            models.Add(model);

            model = new Model()
            {
                Id = 35,
                Name = "C3",
                CategoryId = 1,
                MakeId = 7,
            };
            models.Add(model);

            model = new Model()
            {
                Id = 36,
                Name = "C4",
                CategoryId = 1,
                MakeId = 7,
            };
            models.Add(model);

            //Dacia---------------------
            model = new Model()
            {
                Id = 37,
                Name = "Sandero",
                CategoryId = 2,
                MakeId = 8,
            };
            models.Add(model);

            model = new Model()
            {
                Id = 38,
                Name = "Duster",
                CategoryId = 2,
                MakeId = 8,
            };
            models.Add(model);

            //DS---------------------
            model = new Model()
            {
                Id = 39,
                Name = "7 CROSSBACK",
                CategoryId = 2,
                MakeId = 9,
            };
            models.Add(model);

            model = new Model()
            {
                Id = 40,
                Name = "5LS",
                CategoryId = 1,
                MakeId = 9,
            };
            models.Add(model);

            //Ferrari---------------------
            model = new Model()
            {
                Id = 41,
                Name = "488",
                CategoryId = 1,
                MakeId = 10,
            };
            models.Add(model);

            model = new Model()
            {
                Id = 42,
                Name = "Portofino",
                CategoryId = 1,
                MakeId = 10,
            };
            models.Add(model);

            model = new Model()
            {
                Id = 43,
                Name = "458 Italia",
                CategoryId = 1,
                MakeId = 10,
            };
            models.Add(model);

            //Fiat---------------------
            model = new Model()
            {
                Id = 44,
                Name = "Punto",
                CategoryId = 1,
                MakeId = 11,
            };
            models.Add(model);

            model = new Model()
            {
                Id = 45,
                Name = "500",
                CategoryId = 1,
                MakeId = 11,
            };
            models.Add(model);

            //Ford---------------------
            model = new Model()
            {
                Id = 46,
                Name = "Fiesta",
                CategoryId = 1,
                MakeId = 12,
            };
            models.Add(model);

            model = new Model()
            {
                Id = 47,
                Name = "Mustang",
                CategoryId = 1,
                MakeId = 12,
            };
            models.Add(model);

            //Honda---------------------
            model = new Model()
            {
                Id = 48,
                Name = "Sivic",
                CategoryId = 1,
                MakeId = 13,
            };
            models.Add(model);

            model = new Model()
            {
                Id = 49,
                Name = "Pilot",
                CategoryId = 1,
                MakeId = 13,
            };
            models.Add(model);

            //Hyundai---------------------
            model = new Model()
            {
                Id = 50,
                Name = "Elantra",
                CategoryId = 1,
                MakeId = 14,
            };
            models.Add(model);
            
            model = new Model()
            {
                Id = 51,
                Name = "Tucson",
                CategoryId = 2,
                MakeId = 14,
            };
            models.Add(model);

            //Infiniti---------------------
            model = new Model()
            {
                Id = 52,
                Name = "Q50",
                CategoryId = 1,
                MakeId = 15,
            };
            models.Add(model);

            model = new Model()
            {
                Id = 53,
                Name = "QX50",
                CategoryId = 2,
                MakeId = 15,
            };
            models.Add(model);

            //Jaguar---------------------
            model = new Model()
            {
                Id = 54,
                Name = "F-TYPE",
                CategoryId = 1,
                MakeId = 16,
            };
            models.Add(model);

            model = new Model()
            {
                Id = 55,
                Name = "XF",
                CategoryId = 1,
                MakeId = 16,
            };
            models.Add(model);

            model = new Model()
            {
                Id = 56,
                Name = "F-PACE",
                CategoryId = 2,
                MakeId = 16,
            };
            models.Add(model);

            //Jeep---------------------
            model = new Model()
            {
                Id = 57,
                Name = "Compass",
                CategoryId = 2,
                MakeId = 17,
            };
            models.Add(model);

            model = new Model()
            {
                Id = 58,
                Name = "Cherokee",
                CategoryId = 2,
                MakeId = 17,
            };
            models.Add(model);

            //Kia---------------------
            model = new Model()
            {
                Id = 59,
                Name = "K5",
                CategoryId = 1,
                MakeId = 18,
            };
            models.Add(model);

            model = new Model()
            {
                Id = 60,
                Name = "Sportage",
                CategoryId = 2,
                MakeId = 18,
            };
            models.Add(model);



            return models.ToArray();
        }
    }
}
