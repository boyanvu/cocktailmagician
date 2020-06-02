using CocktailsMagician.Areas.Ingredients.Models;
using CocktailsMagician.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailsMagician.Areas.Cocktails.Models
{
    public class CocktailViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Cocktail name")]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Cocktail description")]
        public string Description { get; set; }

        [DisplayName("Unlisted")]
        public DateTime? UnlistedOn { get; set; }

        [DisplayName("Average rating")]
        public double AvgRating { get; set; }

        public bool IsAvailableInBar { get; set; }
        public List<IngredientViewModel> Ingredients { get; set; }

        [DisplayName("Cocktail ingredients:")]
        public List<CocktailIngredientsViewModel> CocktailIngredients { get; set; }

        public List<CocktailReviewViewModel> CocktailReviews { get; set; } = new List<CocktailReviewViewModel>();
    }
}
