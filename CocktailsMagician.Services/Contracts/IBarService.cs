﻿using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CocktailsMagician.Services.DTO_s;

namespace CocktailsMagician.Services.Contracts
{
    public interface IBarService
    {
        Task<BarDTO> GetBarAsync(Guid id);
        Task<IEnumerable<BarDTO>> GetAllBarsAsync();
        Task<List<BarDTO>> GetAllBarsForHomePage();
        Task<List<BarDTO>> GetBarsFiltered(string sortOrder, string searchString);
        Task<BarDTO> CreateBarAsync(BarDTO barDTO);
        Task<bool> DeleteBarAsync(Guid id);
        Task<BarDTO> UpdateBarAsync(BarDTO barDTO);

        Task<bool> AddCocktailToBarAsync(Guid barId, Guid cocktailId);
        Task<bool> RemoveCocktailFromBarAsync(Guid barId, Guid cocktailId);

        Task<string> CallApiForLocation(string url);
        Task<BarDTO> ParseApiLocationResult(BarDTO barDTO);
        Task<List<BarDTO>> GetBarsWithCocktails(Guid cocktailId, int skip, int take, string searchValue, string sortBy, string orderBy);
        Task<int> GetBarsCount(Guid? cocktailId = null, string searchValue = null);
    }
}
