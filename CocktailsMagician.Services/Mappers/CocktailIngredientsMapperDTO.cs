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
            cocktailIngredientsDTO.UnlistedOn = cocktailIngredient.UnlistedOn;
            cocktailIngredientsDTO.IngredientName = cocktailIngredient.Ingredient.Name;
            //cocktailIngredientsDTO.Quantity = cocktailIngredient.Quantity;
            //cocktailIngredientsDTO.Uom = cocktailIngredient.Uom;

            return cocktailIngredientsDTO;

        }

        public static CocktailIngredientsDTO AllCocktailIngredientMapToDTO(this CocktailIngredients cocktailIngredient)
        {
            var cocktailIngredientsDTO = new CocktailIngredientsDTO();

            cocktailIngredientsDTO.CocktailId = cocktailIngredient.CocktailId;
            cocktailIngredientsDTO.CocktailName = cocktailIngredient.Cocktail.Name;
            cocktailIngredientsDTO.IngredientId = cocktailIngredient.IngredientId;
            cocktailIngredientsDTO.IngredientName = cocktailIngredient.Ingredient.Name;
            cocktailIngredientsDTO.UnlistedOn = cocktailIngredient.UnlistedOn;
            //cocktailIngredientsDTO.Quantity = cocktailIngredient.Quantity;
            //cocktailIngredientsDTO.Uom = cocktailIngredient.Uom;

            return cocktailIngredientsDTO;

        }


        public static CocktailIngredients CocktailIngredientDTOMapToModel(this CocktailIngredientsDTO cocktailIngredientDTO)
        {
            var cocktailIngredients = new CocktailIngredients();

            cocktailIngredients.CocktailId = cocktailIngredientDTO.CocktailId;
            cocktailIngredients.IngredientId = cocktailIngredientDTO.IngredientId;
            cocktailIngredients.UnlistedOn = cocktailIngredientDTO.UnlistedOn;
            //cocktailIngredientsDTO.Quantity = cocktailIngredient.Quantity;
            //cocktailIngredientsDTO.Uom = cocktailIngredient.Uom;
            return cocktailIngredients;

        }
    }

}
