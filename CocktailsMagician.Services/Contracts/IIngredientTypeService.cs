using CocktailsMagician.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsMagician.Services.Contracts
{
    public interface IIngredientTypeService
    {
        Task<IngredientTypeDTO> GetIngredientType(Guid id);
        Task<IEnumerable<IngredientTypeDTO>> GetAllIngredientTypes();
        Task<IngredientTypeDTO> CreateIngredientType(IngredientTypeDTO ingredientTypeDTO);
        Task<IngredientTypeDTO> UpdateIngredientType(Guid id, string ingrTypeName);
        Task<bool> DeleteIngredientType(Guid id);
    }
}
