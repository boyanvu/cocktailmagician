using System;
using System.Collections.Generic;

namespace CocktailsMagician.Data.Entities
{
    public class IngredientType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? UnlistedOn { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
    }
}
