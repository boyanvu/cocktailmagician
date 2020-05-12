using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailsMagician.Services.Mappers
{
    public static class CocktailIngredientsMapperDTO
    {
        public static CocktailIngredientsDTO CocktailIngredientMapToDTO(this CocktailIngredients cocktailIngredient)
        {
            var cocktailIngredientsDTO = new CocktailIngredientsDTO();

            cocktailIngredientsDTO.CocktailId = cocktailIngredient.CocktailId;
            cocktailIngredientsDTO.CocktailName = cocktailIngredient.Cocktail.Name;
            cocktailIngredientsDTO.IngredientId = cocktailIngredient.IngredientId;
            cocktailIngredientsDTO.IngredientName = cocktailIngredient.Ingredient.Name;
            //cocktailIngredientsDTO.Quantity = cocktailIngredient.Quantity;
            //cocktailIngredientsDTO.Uom = cocktailIngredient.Uom;

            return cocktailIngredientsDTO;

        }    
    }

}
