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
using CocktailsMagician.Services.Utilities.Extensions;

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
        public async Task<List<CocktailDTO>> GetAllCocktails()
        {
            var cocktailsDTO = await _cmContext.Cocktails
                .Where(c => c.UnlistedOn == null)
                .Select(c => c.CocktailMapToDTO())
                .ToListAsync();

            return cocktailsDTO;
        }
        public async Task<List<CocktailDTO>> GetAllCocktails(string sortOrder, string searchString)
        {

            var cocktails = (IQueryable<Cocktail>)_cmContext.Cocktails;

         
            if (!String.IsNullOrEmpty(searchString))
            {
                cocktails = cocktails
                    .Where(s => s.Name.Contains(searchString)
                    || s.AvgRating.ToString().Equals(searchString));
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
            var cocktailIngredientsDTO = await GetAllCocktailIngredients();

            var cocktailsDTO = cocktails
                .Where(c => c.UnlistedOn == null)
                .Select(c => c.CocktailMapToDTO());

            //foreach (var cocktail in cocktailsDTO)
            //{
            //    cocktail.CocktailIngredients = cocktailIngredientsDTO.FindAll(cr => cr.CocktailId == cocktail.Id).ToList();
            //}

            return await cocktailsDTO.ToListAsync();
        }

        public async Task<CocktailDTO> GetCocktail(Guid id)
        {
            var cocktail = await _cmContext.Cocktails
                .Include(c => c.CocktailReviews)
                    .ThenInclude(c =>c.User)
                .Include(c => c.CocktailReviews)
                    .ThenInclude(c => c.CocktailReviewLikes)
                    .ThenInclude(c => c.User)
                .FirstOrDefaultAsync(c => c.Id == id);

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

        public async Task<List<CocktailIngredientsDTO>> ShowCocktailIngredients(Guid cocktailId)
        {
            var cocktail = await _cmContext.Cocktails
                   .FirstOrDefaultAsync(c => c.Id == cocktailId);

            if(cocktail == null)
            {
                throw new ArgumentNullException("Cocktail does not exist!");
            }

            var ci =   _cmContext.CocktailIngredients
                   .Include(ci => ci.Ingredient)
                   .Include(ci => ci.Cocktail)
                   .Where(ci => ci.CocktailId == cocktailId)
                   .Select(ci => ci.AllCocktailIngredientMapToDTO());

            return ci.ToList();
        }


        public async Task<List<CocktailIngredientsDTO>> GetAllCocktailIngredients()
        {
            var cocktailIngredientsDTO = await _cmContext.CocktailIngredients
                 .Where(c => c.UnlistedOn == null)
                 .Select(c => c.CocktailIngredientMapToDTO())
                 .ToListAsync();

            return cocktailIngredientsDTO;
        }

        public async Task<bool> IsCocktailAvailableInBar(Guid barId, Guid cocktailId)
        {
            var isAvailable = await _cmContext.BarCocktails
                    .Where(bc => bc.BarId == barId && bc.CocktailId == cocktailId)
                    .AnyAsync(bc => bc.UnlistedOn == null);

            return isAvailable;
        }

        public async Task<List<CocktailDTO>> GetCocktailsInBar(Guid barId, int skip, int take, string searchValue, string sortBy, string orderBy)
        {

            var cocktailsQuery = (IQueryable<Cocktail>)_cmContext.BarCocktails
                .Include(bc => bc.Cocktail)
                .Where(bc => bc.BarId == barId)
                .Skip(skip)
                .Take(take)
                .Select(bc => bc.Cocktail);

            cocktailsQuery = FilterCocktailsBySearchValue(cocktailsQuery, searchValue);
            cocktailsQuery = FilterCocktailsByColumn(cocktailsQuery, sortBy, orderBy);

            return await cocktailsQuery
                        .Select(c => c.CocktailMapToDTO())
                        .ToListAsync();

        }

        private IQueryable<Cocktail> FilterCocktailsBySearchValue(IQueryable<Cocktail> cocktailsQuery, string searchValue)
        {
            return cocktailsQuery = string.IsNullOrEmpty(searchValue)
                   ? cocktailsQuery
                   : cocktailsQuery
                   .Where(c => c.Name.Contains(searchValue));
        }

        private IQueryable<Cocktail> FilterCocktailsByColumn(IQueryable<Cocktail> cocktailsQuery, string sortBy, string orderBy)
        {
            return string.IsNullOrEmpty(sortBy)
                   ? cocktailsQuery
                   : SortCocktails(cocktailsQuery, sortBy, orderBy);
        }
        private IQueryable<Cocktail> SortCocktails(IQueryable<Cocktail> cocktailsQuery, string sortBy, string orderBy)
        {
            return orderBy == "asc"
                    ? cocktailsQuery.OrderBy(sortBy)
                    : cocktailsQuery.OrderByDescending(sortBy);
        }
        public async Task<int> GetCocktailsCount(Guid? barId = null, string searchValue = null)
        {

            var cocktails = barId == null
              ? _cmContext.Cocktails
              : _cmContext.BarCocktails
                  .Include(bc => bc.Cocktail)
                  .Where(bc => bc.BarId == barId.Value)
                  .Select(bc => bc.Cocktail);

            var count = string.IsNullOrEmpty(searchValue)
                ? cocktails.CountAsync()
                : cocktails
                    .Where(c => c.Name.Contains(searchValue))
                    .CountAsync();

            return await count;
        }
    }
}
