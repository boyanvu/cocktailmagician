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


        public async Task<CocktailIngredientsDTO> AddIngredientToCocktail(CocktailIngredientsDTO cocktailIngredientDTO)
        {
            if (cocktailIngredientDTO == null)
            {
                throw new ArgumentNullException("CocktailIngredient doesn't exist!");
            }

            if (cocktailIngredientDTO.UnlistedOn != null)
            {
                var cocktailIngredient = await _cmContext.CocktailIngredients
                    .FirstOrDefaultAsync(ci => ci.CocktailId == cocktailIngredientDTO.CocktailId
                    && ci.IngredientId == cocktailIngredientDTO.IngredientId);

                cocktailIngredient.UnlistedOn = null;
            }
            else
            {
                var cocktailIngredient = cocktailIngredientDTO.CocktailIngredientDTOMapToModel();
                await _cmContext.CocktailIngredients.AddAsync(cocktailIngredient);               
            }
            await _cmContext.SaveChangesAsync();

            return cocktailIngredientDTO;
        }

        public async Task<bool> RemoveIngredientFromCocktail(Guid cocktailId, Guid ingredientId)
        {
            var cocktailIngredient = await _cmContext.CocktailIngredients
                 .Where(ci => ci.CocktailId == cocktailId && ci.IngredientId == ingredientId)
                 .FirstOrDefaultAsync(bc => bc.UnlistedOn == null);

            if (cocktailIngredient == null)
            {
                throw new ArgumentNullException("Cocktail - ingredient doesn't exist!");
            }

            cocktailIngredient.UnlistedOn = DateTime.UtcNow;

            await _cmContext.SaveChangesAsync();

            return true;
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

        public async Task<bool> DoesCocktailHaveIngredient(Guid cocktailId, Guid ingredientId)
        {
            var hasIngredient = await _cmContext.CocktailIngredients
                    .Where(ci => ci.CocktailId == cocktailId && ci.IngredientId == ingredientId)
                    .AnyAsync(ci => ci.UnlistedOn == null);

            return hasIngredient;
        }

        public async Task<bool> IngredientIsUnlisted(Guid cocktailId, Guid ingredientId)
        {
            var cocktailIngredient = await _cmContext.CocktailIngredients
                    .FirstOrDefaultAsync(ci => ci.CocktailId == cocktailId && ci.IngredientId == ingredientId);

           if(cocktailIngredient == null)
            {
                return false;
            }

            var isUnlisted = false;

            if(cocktailIngredient.UnlistedOn == null)
            {
                isUnlisted = false;
            }
            else
            {
                isUnlisted = true;
            }

            return isUnlisted;
        }

        public async Task<CocktailIngredientsDTO> GetCocktailIngredient(Guid cocktailId, Guid ingredientId)
        {
            var ci = await _cmContext.CocktailIngredients
                   .FirstOrDefaultAsync(ci => ci.CocktailId == cocktailId && ci.IngredientId == ingredientId);

            if(ci == null)
            {
                return null;
            }

            return ci.CocktailIngredientMapToDTO();
        }


    }
}
