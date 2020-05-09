using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailsMagician.Data.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Abv { get; set; }
        public string Description { get; set; }
        public DateTime? UnlistedOn { get; set; }
        public int TypeId { get; set; }
        public IngredientType Type { get; set; }

    }
}
