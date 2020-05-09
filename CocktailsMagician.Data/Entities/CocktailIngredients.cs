using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailsMagician.Data.Entities
{
    public class CocktailIngredients
    {
        public int CocktailId { get; set; }
        public Cocktail Cocktail { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public int Quantity { get; set; }
        public string Uom { get; set; }

    }
}
