using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailsMagician.Services.Mappers
{
    public static class CocktailMapperDTO
    {
        public static CocktailDTO CocktailMapToDTO(this Cocktail cocktail)
        {
            var cocktailDTO = new CocktailDTO();
            cocktailDTO.Id = cocktail.Id;
            cocktailDTO.Name = cocktail.Name;
            cocktailDTO.Description = cocktail.Description;
            cocktailDTO.UnlistedOn = cocktail.UnlistedOn;
            cocktailDTO.AvgRating = cocktail.AvgRating;
            if (cocktail.CocktailReviews != null)
            {
                cocktailDTO.CocktailReviews = cocktail.CocktailReviews.Select(c => c.CocktailMapReviewDTO()).ToList();
            }
            if (cocktail.CocktailIngredients != null)
            {
                cocktailDTO.CocktailIngredients = cocktail.CocktailIngredients.Select(c => c.CocktailIngredientMapToDTO()).ToList();
            }


            return cocktailDTO;
        }

        public static Cocktail CocktailDTOMapToModel(this CocktailDTO cocktailDTO)
        {
            var cocktail = new Cocktail();
            cocktail.Id = cocktailDTO.Id;
            cocktail.Name = cocktailDTO.Name;
            cocktail.Description = cocktailDTO.Description;
            cocktail.UnlistedOn = cocktailDTO.UnlistedOn;
            cocktail.AvgRating = cocktailDTO.AvgRating;

            return cocktail;
        }
    }
}
