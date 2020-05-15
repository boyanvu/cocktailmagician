using CocktailsMagician.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsMagician.Services.Contracts
{
    public interface IIngredientService
    {
        Task<IngredientDTO> GetIngredient(Guid id);
        Task<List<IngredientDTO>> GetAllIngredients(string sortOrder, string currentFilter, string searchString, int? page);
        Task<IngredientDTO> CreateIngredient(IngredientDTO ingredientDTO);
        Task<IngredientDTO> UpdateIngredient(Guid id, string ingrName, double? ingrAbv, string ingrDescription, Guid ingrTypeId);
        Task<bool> DeleteIngredient(Guid id);
    }
}
