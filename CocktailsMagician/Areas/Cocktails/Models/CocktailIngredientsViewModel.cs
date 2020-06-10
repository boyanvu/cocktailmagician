using System;

namespace CocktailsMagician.Areas.Cocktails.Models
{
    public class CocktailIngredientsViewModel
    {
        public Guid CocktailId { get; set; }
        public String CocktailName { get; set; }
        public Guid IngredientId { get; set; }
        public String IngredientName { get; set; }
    }
}
