using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services.DTO_s;

namespace CocktailsMagician.Services.Mappers
{
    public static class IngredientTypeMapperDTO
    {
        public static IngredientTypeDTO IngredientTypeMapToDTO(this IngredientType ingredientType)
        {
            var ingredientTypeDTO = new IngredientTypeDTO();
            ingredientTypeDTO.Id = ingredientType.Id;
            ingredientTypeDTO.Name = ingredientType.Name;
            ingredientTypeDTO.Ingredients = ingredientType.Ingredients;

            return ingredientTypeDTO;
        }

        public static IngredientType IngredientTypeDTOMapToModel(this IngredientTypeDTO ingredientTypeDTO)
        {
            var ingredientType = new IngredientType();
            ingredientType.Id = ingredientTypeDTO.Id;
            ingredientType.Name = ingredientTypeDTO.Name;
            ingredientType.Ingredients = ingredientTypeDTO.Ingredients;

            return ingredientType;
        }
    }
}
