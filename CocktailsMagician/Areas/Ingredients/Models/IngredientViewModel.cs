using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CocktailsMagician.Areas.Ingredients.Models
{
    public class IngredientViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Ingredient name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Alcohol by volume")]
        public double Abv { get; set; }

        [DisplayName("Desciption")]
        public string Description { get; set; }
        public DateTime? UnlistedOn { get; set; }

        [Required]
        [DisplayName("Ingredient type Id")]
        public Guid TypeId { get; set; }

        [DisplayName("Ingredient type name")]
        public String TypeName { get; set; }
        public bool isSelected { get; set; }

    }
}
