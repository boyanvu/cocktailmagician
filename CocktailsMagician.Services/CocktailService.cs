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
using CocktailsMagician.Data.Entities;

namespace CocktailsMagician.Services
{
    public class CocktailService : ICocktailService
    {
        private readonly CMContext _cmContext;
        public CocktailService(CMContext context)
        {
            this._cmContext = context;
        }

        public async Task<CocktailIngredientsDTO> AddIngredientToCocktail(CocktailIngredientsDTO cocktailIngredientDTO)
        {

            if (cocktailIngredientDTO == null)
            {
                throw new ArgumentNullException("CocktailIngredient doesn't exist!");
            }

            var cocktailIngredient = cocktailIngredientDTO.CocktailIngredientDTOMapToModel();

            await _cmContext.CocktailIngredients.AddAsync(cocktailIngredient);
            await _cmContext.SaveChangesAsync();

            return cocktailIngredientDTO;
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

        public async Task<List<CocktailDTO>> GetAllCocktails(string sortOrder, string currentFilter, string searchString, int? page)
        {

            var cocktails = (IQueryable<Cocktail>)_cmContext.Cocktails;

         
            if (!String.IsNullOrEmpty(searchString))
            {
                cocktails = cocktails
                    .Where(s => s.Name.Contains(searchString));                                      
            }

            switch (sortOrder)
            {
                case "name_desc":
                    cocktails = cocktails.OrderByDescending(s => s.Name);
                    break;
                case "rating":
                    cocktails = cocktails.OrderBy(s => s.AvgRating);
                    break;
                case "rating_desc":
                    cocktails = cocktails.OrderByDescending(s => s.AvgRating);
                    break;
                default:
                    cocktails = cocktails.OrderBy(c => c.Name);
                    break;
            }

            var cocktailsDTO = cocktails
                .Where(c => c.UnlistedOn == null)
                .Select(c => c.CocktailMapToDTO());


            return await cocktailsDTO.ToListAsync();
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
