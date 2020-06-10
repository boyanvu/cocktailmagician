using CocktailsMagician.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsMagician.Services.Contracts
{
    public interface ICocktailService
    {
        Task<CocktailDTO> GetCocktail(Guid id);
        Task<List<CocktailDTO>> GetAllCocktails(string sortOrder, string searchString);
        Task<List<CocktailDTO>> GetAllCocktails();
        Task<List<CocktailDTO>> GetAllCocktailsForHomePage();
        Task<bool> IsCocktailAvailableInBar(Guid barId, Guid cocktailId);
        Task<CocktailDTO> CreateCocktail(CocktailDTO cocktailtDTO);
        Task<CocktailDTO> UpdateCocktail(Guid id, string cName, string cDescription);
        Task<bool> DeleteCocktail(Guid id);
        Task<CocktailIngredientsDTO> AddIngredientToCocktail(CocktailIngredientsDTO cocktailIngredientDTO);
        Task<bool> RemoveIngredientFromCocktail(Guid cocktailId, Guid ingredientId);
        Task<bool> DoesCocktailHaveIngredient(Guid cocktailId, Guid ingredientId);
        Task<bool> IngredientIsUnlisted(Guid cocktailId, Guid ingredientId);
        Task<CocktailIngredientsDTO> GetCocktailIngredient(Guid cocktailId, Guid ingredientId);
        Task<List<CocktailIngredientsDTO>> ShowCocktailIngredients(Guid cocktailId);
        Task<List<CocktailIngredientsDTO>> GetAllCocktailIngredients();
        Task<List<CocktailDTO>> GetCocktailsInBar(Guid barId, int skip, int take, string searchValue, string sortBy, string orderBy);
        Task<int> GetCocktailsCount(Guid? barId = null, string searchValue = null);


    }
}
