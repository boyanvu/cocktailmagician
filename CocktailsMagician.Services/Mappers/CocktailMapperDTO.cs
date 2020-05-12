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

        public static Cocktail CocktailDTOMapToModel(this CocktailDTO cocktailDTO)
        {
            var cocktail = new Cocktail();
            cocktail.Id = cocktailDTO.Id;
            cocktail.Name = cocktailDTO.Name;
            cocktail.Description = cocktailDTO.Description;
            cocktail.UnlistedOn = cocktailDTO.UnlistedOn;
            cocktail.AvgRating = cocktailDTO.AvgRating;
            cocktail.CocktailReviews = cocktailDTO.CocktailReviews;


            return cocktail;
        }
    }
}
