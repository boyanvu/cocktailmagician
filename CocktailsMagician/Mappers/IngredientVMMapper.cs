using CocktailsMagician.Areas.Ingredients.Models;
using CocktailsMagician.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailsMagician.Mappers
{
    public static class IngredientVMMapper
    {
        public static IngredientViewModel IngredientDTOMapToVM(this IngredientDTO ingredientDTO)
        {
            var ingredientVM = new IngredientViewModel();
            ingredientVM.Id = ingredientDTO.Id;
            ingredientVM.Name = ingredientDTO.Name;
            ingredientVM.Description = ingredientDTO.Description;
            ingredientVM.UnlistedOn = ingredientDTO.UnlistedOn;
            ingredientVM.Abv = ingredientDTO.Abv;
            ingredientVM.TypeId = ingredientDTO.TypeId;
            ingredientVM.TypeName = ingredientDTO.TypeName;


            return ingredientVM;
        }
    }
}
