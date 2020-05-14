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
        Task<IQueryable<CocktailDTO>> GetAllCocktails(string sortOrder, string currentFilter, string searchString, int? page);
        Task<CocktailDTO> CreateCocktail(CocktailDTO cocktailtDTO);
        Task<CocktailDTO> UpdateCocktail(Guid id, string cName, string cDescription);
        Task<bool> DeleteCocktail(Guid id);
    }
}
