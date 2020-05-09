using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailsMagician.Data.Entities
{
    public class Bar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public DateTime? UnlistedOn { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
