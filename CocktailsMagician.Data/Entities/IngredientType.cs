using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailsMagician.Data.Entities
{
    public class IngredientType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
    }
}
