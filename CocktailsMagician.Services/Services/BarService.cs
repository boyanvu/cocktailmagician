using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocktailsMagician.Data;
using CocktailsMagician.Services.Contracts;
using CocktailsMagician.Services.DTO_s;
using Microsoft.EntityFrameworkCore;
using CocktailsMagician.Services.Mappers;

namespace CocktailsMagician.Services.Services
{
    public class BarService : IBarService
    {
        private readonly CMContext _cmContext;
        public BarService(CMContext cmContext)
        {
            this._cmContext = cmContext;
        }
        public async Task<BarDTO> GetBarAsync(Guid id)
        {
            var bar = await _cmContext.Bars
                .FirstOrDefaultAsync(b => b.Id == id);
            if (bar == null)
            {
                throw new ArgumentNullException();
            }
            var barDto = bar.MapBarToDTO();
            return barDto;
        }

        public async Task<IEnumerable<BarDTO>> GetAllBarsAsync()
        {
            var barsDto = await _cmContext.Bars
                .Select(b => b.MapBarToDTO())
                .ToListAsync();
            return barsDto;
        }
        public async Task<BarDTO> CreateBarAsync(BarDTO barDTO)
        {
            try
            {
                var bar = barDTO.BarDTOMapToModel();
                await _cmContext.Bars.AddAsync(bar);
                await _cmContext.SaveChangesAsync();
                return barDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BarDTO> UpdateBarAsync(Guid id, string name, string phone, string website, string description, Guid cityId, string address)
        {
            var bar = await _cmContext.Bars
                .FirstOrDefaultAsync(b => b.UnlistedOn == null);

            if (bar == null)
            {
                throw new ArgumentNullException();
            }

            if (name != null)
                bar.Name = name;

            if (phone != null)
                bar.Phone = phone;

            if (website != null)
                bar.Website = website;

            if (description != null)
                bar.Description = description;

            if (cityId != null)
                if (await _cmContext.Cities.FindAsync(cityId) == null)
                {
                    throw new ArgumentException();
                }
            bar.CityId = cityId;

            if (address != null)
                bar.Address = address;

            await _cmContext.SaveChangesAsync();

            var barDto = await this.GetBarAsync(id);
            return barDto;
        }

        public async Task<bool> DeleteBarAsync(Guid id)
        {
            var bar = await _cmContext.Bars
                .Where(b => b.UnlistedOn == null)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (bar == null)
            {
                return false;
            }
            bar.UnlistedOn = DateTime.UtcNow;
            await _cmContext.SaveChangesAsync();
            return true;
        }
    }
}
