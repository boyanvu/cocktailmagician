using CocktailsMagician.Data;
using CocktailsMagician.Services.Contracts;
using CocktailsMagician.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CocktailsMagician.Services.Mappers;
using Microsoft.EntityFrameworkCore;

namespace CocktailsMagician.Services
{
    public class IngredientTypeService : IIngredientTypeService
    {
        private readonly CMContext _cmContext;
        public IngredientTypeService(CMContext context)
        {
            this._cmContext = context;
        }

        public async Task<IngredientTypeDTO> CreateIngredientType(IngredientTypeDTO ingredientTypeDTO)
        {
            if (ingredientTypeDTO == null)
            {
                throw new ArgumentNullException("Ingredient type doesn't exist!");
            }

            var ingredientType = ingredientTypeDTO.IngredientTypeDTOMapToModel();

            await _cmContext.IngredientTypes.AddAsync(ingredientType);
            await _cmContext.SaveChangesAsync();

            return ingredientTypeDTO;
        }

        public async Task<bool> DeleteIngredientType(Guid id)
        {
            var ingredientType = await _cmContext.IngredientTypes
           .FirstOrDefaultAsync(it => it.Id == id);

            if (ingredientType == null)
            {
                throw new ArgumentNullException("Ingredient type doesn't exist!");
            }

            await this._cmContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<IngredientTypeDTO>> GetAllIngredientTypes()
        {
            return await _cmContext.IngredientTypes
                .Select(it => it.IngredientTypeMapToDTO())
                .ToListAsync();
        }

        public async Task<IngredientTypeDTO> GetIngredientType(Guid id)
        {
            var ingredientType = await _cmContext.IngredientTypes
                .FirstOrDefaultAsync(it => it.Id == id);

            if (ingredientType == null)
            {
                throw new ArgumentNullException("Ingredient type doesn't exist!");
            }

            return ingredientType.IngredientTypeMapToDTO();
        }

        public async Task<IngredientTypeDTO> UpdateIngredientType(Guid id, string ingrTypeName)
        {
            var igredientType = await _cmContext.IngredientTypes
             .FirstOrDefaultAsync(i => i.Id == id);

            if (igredientType == null)
            {
                throw new ArgumentNullException("Ingredient type doesn't exist!");
            }

            if (ingrTypeName != null)
                igredientType.Name = ingrTypeName;


            await _cmContext.SaveChangesAsync();

            return igredientType.IngredientTypeMapToDTO();
        }
    }
}
