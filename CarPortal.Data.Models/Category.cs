﻿using System.ComponentModel.DataAnnotations;
using static CarPortal.Common.EntityValidationConstants.Category;

namespace CarPortal.Data.Models
{
    public class Category
    {
        public Category()
        {
            Cars = new HashSet<Car>();
            Models = new HashSet<Model>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Car> Cars { get; set; }

        public ICollection<Model> Models { get; set; }
    }
}
