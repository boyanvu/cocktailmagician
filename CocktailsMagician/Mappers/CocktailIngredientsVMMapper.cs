using CocktailsMagician.Areas.Cocktails.Models;
using CocktailsMagician.Services.DTO_s;

namespace CocktailsMagician.Mappers
{
    public static class CocktailIngredientsVMMapper
    {
        public static CocktailIngredientsViewModel CocktailIngredientDTOMapToVM(this CocktailIngredientsDTO cocktailIngredientDTO)
        {
            var cocktailIngredients = new CocktailIngredientsViewModel();

            cocktailIngredients.CocktailId = cocktailIngredientDTO.CocktailId;
            cocktailIngredients.IngredientId = cocktailIngredientDTO.IngredientId;
            cocktailIngredients.CocktailName = cocktailIngredientDTO.CocktailName;
            cocktailIngredients.IngredientName = cocktailIngredientDTO.IngredientName;
            //cocktailIngredientsDTO.Quantity = cocktailIngredient.Quantity;
            //cocktailIngredientsDTO.Uom = cocktailIngredient.Uom;
            return cocktailIngredients;

        }
    }
}
