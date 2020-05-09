using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailsMagician.Data.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Bar> Bars { get; set; }

    }
}
