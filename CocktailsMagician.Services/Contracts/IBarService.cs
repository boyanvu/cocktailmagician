using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CocktailsMagician.Services.DTO_s;

namespace CocktailsMagician.Services.Contracts
{
    public interface IBarService
    {
        Task<BarDTO> GetBarAsync(Guid id);
        Task<IEnumerable<BarDTO>> GetAllBarsAsync();
        Task<BarDTO> CreateBarAsync(BarDTO barDTO);
        Task<bool> DeleteBarAsync(Guid id);
        Task<BarDTO> UpdateBarAsync(/*Guid id, string name, string phone, string website, string description, Guid cityId, string address*/BarDTO barDTO);
    }
}
