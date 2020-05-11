using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services.DTO_s;
using System;
using System.Collections.Generic;
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
            cocktailDTO.CocktailReviews = cocktail.CocktailReviews;

            return cocktailDTO;
        }
    }
}
