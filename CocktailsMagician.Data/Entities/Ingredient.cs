using System;
using System.Collections.Generic;

namespace CocktailsMagician.Data.Entities
{
    public class Ingredient
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Abv { get; set; }
        public string Description { get; set; }
        public DateTime? UnlistedOn { get; set; }
        public Guid TypeId { get; set; }
        public IngredientType Type { get; set; }
        public ICollection<CocktailIngredients> CocktailIngredients { get; set; }

    }
}
