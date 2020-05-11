using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailsMagician.Services.Mappers
{
    public static class IngredientTypeMapperDTO
    {
        public static IngredientTypeDTO IngredientMapToDTO(this IngredientType ingredientType)
        {
            var ingredientTypeDTO = new IngredientTypeDTO();
            ingredientTypeDTO.Id = ingredientType.Id;
            ingredientTypeDTO.Name = ingredientType.Name;
            ingredientTypeDTO.Ingredients = ingredientType.Ingredients;

            return ingredientTypeDTO;
        }
    }
}
