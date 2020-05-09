using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailsMagician.Data.Entities
{
    public class BarCocktail
    {
        public int BarId { get; set; }
        public Bar Bar { get; set; }
        public int CocktailId { get; set; }
        public Cocktail Cocktail { get; set; }
        public DateTime? UnlistedOn { get; set; }
    }
}
