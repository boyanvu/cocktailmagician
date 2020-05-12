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
        Task<IEnumerable<IngredientDTO>> GetAllIngredients();
        Task<IngredientDTO> CreateIngredient(IngredientDTO ingredientDTO);
        Task<IngredientDTO> UpdateIngredient(Guid id, string ingrName, double? ingrAbv, string ingrDescription, int ingrTypeId);
        Task<bool> DeleteIngredient(Guid id);
    }
}
