using CocktailsMagician.Areas.Cocktails.Models;
using CocktailsMagician.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailsMagician.Mappers
{
    public static class CocktailVMMapper
    {
        public static CocktailViewModel CocktailDTOMapToVM(this CocktailDTO cocktailDTO)
        {
            var cocktailVM = new CocktailViewModel();
            cocktailVM.Id = cocktailDTO.Id;
            cocktailVM.Name = cocktailDTO.Name;
            cocktailVM.Description = cocktailDTO.Description;
            cocktailVM.UnlistedOn = cocktailDTO.UnlistedOn;
            cocktailVM.AvgRating = cocktailDTO.AvgRating;
            if (cocktailDTO.CocktailReviews != null)
            {
                cocktailVM.CocktailReviews = cocktailDTO.CocktailReviews.Select(c => c.CocktailReviewsDTOMapToVM()).ToList();
            }
            if (cocktailDTO.CocktailIngredients != null)
            {
                cocktailVM.CocktailIngredients = cocktailDTO.CocktailIngredients.Select(c => c.CocktailIngredientDTOMapToVM()).ToList();
            }
            return cocktailVM;
        }
    }
}
