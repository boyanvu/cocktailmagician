﻿using System;

namespace CocktailsMagician.Data.Entities
{
    public class BarCocktail
    {
        public Guid BarId { get; set; }
        public Bar Bar { get; set; }
        public Guid CocktailId { get; set; }
        public Cocktail Cocktail { get; set; }
        public DateTime? UnlistedOn { get; set; }
    }
}
