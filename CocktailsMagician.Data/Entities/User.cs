using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailsMagician.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string  Username { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
