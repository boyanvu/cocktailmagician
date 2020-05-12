using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailsMagician.Services.Mappers
{
    public static class IngredientMapperDTO
    {
        public static IngredientDTO IngredientMapToDTO(this Ingredient ingredient)
        {
            var ingredientDTO = new IngredientDTO();
            ingredientDTO.Id = ingredient.Id;
            ingredientDTO.Name = ingredient.Name;
            ingredientDTO.Id = ingredient.Id;
            ingredientDTO.Abv = ingredient.Abv;
            ingredientDTO.Description = ingredient.Description;
            ingredientDTO.UnlistedOn = ingredient.UnlistedOn;
            ingredientDTO.TypeId = ingredient.TypeId;
            ingredientDTO.TypeName = ingredient.Type.Name;

            return ingredientDTO;
        }

        public static Ingredient IngredientDTOMapToModel(this IngredientDTO ingredientDTO)
        {
            var ingredient = new Ingredient();
            ingredient.Id = ingredientDTO.Id;
            ingredient.Name = ingredientDTO.Name;
            ingredient.Id = ingredientDTO.Id;
            ingredient.Abv = ingredientDTO.Abv;
            ingredient.Description = ingredientDTO.Description;
            ingredient.UnlistedOn = ingredientDTO.UnlistedOn;
            ingredient.TypeId = ingredientDTO.TypeId;

            return ingredient;
        }
    }
}
