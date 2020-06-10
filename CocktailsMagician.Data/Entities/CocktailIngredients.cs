﻿using System;

namespace CocktailsMagician.Data.Entities
{
    public class CocktailIngredients
    {
        public Guid CocktailId { get; set; }
        public Cocktail Cocktail { get; set; }
        public Guid IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public DateTime? UnlistedOn { get; set; }

        //public int Quantity { get; set; }
        //public string Uom { get; set; }

    }
}
