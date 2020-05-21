using CocktailsMagician.Areas.Ingredients.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
