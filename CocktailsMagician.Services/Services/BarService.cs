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
                .Include(b=>b.City)
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
                .Include(b => b.City)
                .Select(b => b.MapBarToDTO())
                .ToListAsync();
            return barsDto;
        }
        public async Task<BarDTO> CreateBarAsync(BarDTO barDTO)
        {
            try
            {
                var bar = barDTO.BarDTOMapToModel();
                _cmContext.Bars.Add(bar);
                await _cmContext.SaveChangesAsync();
                return barDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BarDTO> UpdateBarAsync(/*Guid id, string name, string phone, string website, string description, Guid cityId, string address*/BarDTO barDTO)
        {
            var bar = await _cmContext.Bars
                .Where(b=>b.Id == barDTO.Id)
                .FirstOrDefaultAsync(b => b.UnlistedOn == null);

            if (bar == null)
            {
                throw new ArgumentNullException();
            }

            if (barDTO.Name != null)
                bar.Name = barDTO.Name;

            if (barDTO.Phone != null)
                bar.Phone = barDTO.Phone;

            if (barDTO.Website != null)
                bar.Website = barDTO.Website;

            if (barDTO.Description != null)
                bar.Description = barDTO.Description;

            if (barDTO.CityId != null)
            {
                if (!await _cmContext.Cities.AnyAsync(c => c.Id == barDTO.CityId))
                {
                    throw new ArgumentException();
                }
                bar.CityId = barDTO.CityId;
            }

            if (barDTO.Address != null)
                bar.Address = barDTO.Address;


                await _cmContext.SaveChangesAsync();

           
            //var barDto = bar.MapBarToDTO();
            return barDTO;
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
