using System;

namespace CocktailsMagician.Services.DTO_s
{
    public class BarCocktailDTO
    {
        public Guid BarId { get; set; }
        public String BarName { get; set; }
        public Guid CocktailId { get; set; }
        public String CocktailName { get; set; }
        public DateTime? UnlistedOn { get; set; }
    }
}
