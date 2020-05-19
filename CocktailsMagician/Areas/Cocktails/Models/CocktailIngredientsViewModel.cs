using CocktailsMagician.Areas.Ingredients.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailsMagician.Areas.Cocktails.Models
{
    public class CocktailIngredientsViewModel
    {
        public IngredientViewModel IngredientName { get; set; }
        public bool IsSelected { get; set; }
    }
}
