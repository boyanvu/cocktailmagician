using CocktailsMagician.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailsMagician.Services.DTO_s
{
    public class CocktailIngredientsDTO
    {
        public Guid CocktailId { get; set; }
        public String CocktailName { get; set; }
        public Guid IngredientId { get; set; }
        public String IngredientName { get; set; }
        public int Quantity { get; set; }
        public string Uom { get; set; }
    }
}
