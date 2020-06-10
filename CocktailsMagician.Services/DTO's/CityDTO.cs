using CocktailsMagician.Data.Entities;
using System;
using System.Collections.Generic;

namespace CocktailsMagician.Services.DTO_s
{
    public class CityDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Bar> Bars { get; set; }

    }
}
