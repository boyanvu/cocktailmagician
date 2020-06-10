using System;
using System.Collections.Generic;

namespace CocktailsMagician.Services.DTO_s
{
    public class CocktailDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? UnlistedOn { get; set; }
        public double AvgRating { get; set; }
        public ICollection<CocktailReviewDTO> CocktailReviews { get; set; }
        public ICollection<CocktailIngredientsDTO> CocktailIngredients { get; set; }
    }
}
