using CocktailsMagician.Data;
using CocktailsMagician.Services.Contracts;
using CocktailsMagician.Services.DTO_s;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocktailsMagician.Services.Mappers;

namespace CocktailsMagician.Services
{
    public class CocktailService : ICocktailService
    {
        private readonly CMContext _cmContext;
        public CocktailService(CMContext context)
        {
            this._cmContext = context;
        }

        public async Task<CocktailDTO> CreateCocktail(CocktailDTO cocktailDTO)
        {
            if (cocktailDTO == null)
            {
                throw new ArgumentNullException("Cocktail doesn't exist!");
            }

            var cocktail = cocktailDTO.CocktailDTOMapToModel();

            await _cmContext.Cocktails.AddAsync(cocktail);
            await _cmContext.SaveChangesAsync();

            return cocktailDTO;
        }

        public async Task<bool> DeleteCocktail(Guid id)
        {
            var cocktail = await _cmContext.Cocktails
              .FirstOrDefaultAsync(i => i.Id == id);

            if (cocktail == null)
            {
                throw new ArgumentNullException("Cocktail doesn't exist!");
            }

            cocktail.UnlistedOn = DateTime.UtcNow;
            await this._cmContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<CocktailDTO>> GetAllCocktails()
        {
            return await _cmContext.Cocktails
               .Where(c => c.UnlistedOn == null)
               .Select(c => c.CocktailMapToDTO())
               .ToListAsync();
        }

        public async Task<CocktailDTO> GetCocktail(Guid id)
        {
            var cocktail = await _cmContext.Cocktails
                .FirstOrDefaultAsync(i => i.Id == id);

            if (cocktail == null)
            {
                throw new ArgumentNullException("Cocktail doesn't exist!");
            }

            return cocktail.CocktailMapToDTO();
        }

        public async Task<CocktailDTO> UpdateCocktail(Guid id, string cName,  string cDescription)
        {
            var cocktail = await _cmContext.Cocktails
               .Where(i => i.UnlistedOn == null)
               .FirstOrDefaultAsync(i => i.Id == id);

            if (cocktail == null)
            {
                throw new ArgumentNullException("Cocktail doesn't exist!");
            }

            if (cName != null)
                cocktail.Name = cName;

            if (cDescription != null)
                cocktail.Description = cDescription;

         
            await _cmContext.SaveChangesAsync();

            return cocktail.CocktailMapToDTO();
        }
    }
}
