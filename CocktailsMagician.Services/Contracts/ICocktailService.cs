using CocktailsMagician.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsMagician.Services.Contracts
{
    public interface ICocktailService
    {
        Task<CocktailDTO> GetCocktail(Guid id);
        Task<IEnumerable<CocktailDTO>> GetAllCocktails();
        Task<CocktailDTO> CreateCocktail(CocktailDTO cocktailtDTO);
        Task<CocktailDTO> UpdateCocktail(Guid id, string cName, string cDescription);
        Task<bool> DeleteCocktail(Guid id);
    }
}
