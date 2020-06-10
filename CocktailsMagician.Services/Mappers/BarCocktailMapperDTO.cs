using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services.DTO_s;

namespace CocktailsMagician.Services.Mappers
{
    public static class BarCocktailMapperDTO
    {
        public static BarCocktailDTO BarCocktailMapToDTO(this BarCocktail barCocktail)
        {
            var barCocktailDTO = new BarCocktailDTO();
            barCocktailDTO.BarId = barCocktail.BarId;
            barCocktailDTO.BarName = barCocktail.Bar.Name;
            barCocktailDTO.CocktailId = barCocktail.CocktailId;
            barCocktailDTO.CocktailName = barCocktail.Cocktail.Name;
            barCocktailDTO.UnlistedOn = barCocktail.UnlistedOn;

            return barCocktailDTO;
        }
    }
}
