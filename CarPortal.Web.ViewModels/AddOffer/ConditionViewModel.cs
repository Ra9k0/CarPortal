using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static CarPortal.Common.EntityValidationConstants.Condition;

namespace CarPortal.Web.ViewModels.AddOffer
{
    public class ConditionViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
