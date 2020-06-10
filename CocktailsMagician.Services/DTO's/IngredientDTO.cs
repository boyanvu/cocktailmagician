using System;

namespace CocktailsMagician.Services.DTO_s
{
    public class IngredientDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Abv { get; set; }
        public string Description { get; set; }
        public DateTime? UnlistedOn { get; set; }
        public Guid TypeId { get; set; }
        public String TypeName { get; set; }

    }
}
