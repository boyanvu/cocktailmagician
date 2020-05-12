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
    public class IngredientService : IIngredientService
    {
        private readonly CMContext _cmContext;
        public IngredientService(CMContext context)
        {
            this._cmContext = context;
        }

        public async Task<IngredientDTO> CreateIngredient(IngredientDTO ingredientDTO)
        {
            if (ingredientDTO == null)
            {
                throw new ArgumentNullException("Ingredient doesn't exist!");
            }

            var ingredient = ingredientDTO.IngredientDTOMapToModel();

            await _cmContext.Ingredients.AddAsync(ingredient);
            await _cmContext.SaveChangesAsync();

            return ingredientDTO;
        }

        public async Task<bool> DeleteIngredient(Guid id)
        {
            var ingredient = await _cmContext.Ingredients
                .FirstOrDefaultAsync(i => i.Id == id);

            if(ingredient == null)
            {
                throw new ArgumentNullException("Ingredient doesn't exist!");
            }

            ingredient.UnlistedOn = DateTime.UtcNow;
            await this._cmContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<IngredientDTO>> GetAllIngredients()
        {
            return await _cmContext.Ingredients
                .Where(i => i.UnlistedOn == null)
                .Include(i => i.Type)
                .Select(i => i.IngredientMapToDTO())
                .ToListAsync();
        }

        public async Task<IngredientDTO> GetIngredient(Guid id)
        {
            var ingredient = await _cmContext.Ingredients
                .FirstOrDefaultAsync(i => i.Id == id);

            if(ingredient == null)
            {
                throw new ArgumentNullException("Ingredient doesn't exist!");
            }

            return ingredient.IngredientMapToDTO();
        }

        public async Task<IngredientDTO> UpdateIngredient(Guid id, string ingrName, double? ingrAbv, string ingrDescription, int ingrTypeId)
        {
            var igredient = await _cmContext.Ingredients
               .Where(i => i.UnlistedOn == null)
               .FirstOrDefaultAsync(i => i.Id == id);

            if (igredient == null)
            {
                throw new ArgumentNullException("Ingredient doesn't exist!");
            }

            if (ingrName != null)
                igredient.Name = ingrName;

            if (ingrAbv != null)
                igredient.Abv = (double)ingrAbv;

            if (ingrDescription != null)
                igredient.Description = ingrDescription;

       
            if (ingrTypeId != 0)
            {
                var ingrType = await _cmContext.IngredientTypes.FindAsync(ingrTypeId);
                if (ingrType == null)
                {
                    throw new ArgumentException("Provided ingredient type is not valid!");
                }
                igredient.TypeId = ingrType.Id;
            }
            ;
            await _cmContext.SaveChangesAsync();

            return igredient.IngredientMapToDTO();
        }
    }
}
