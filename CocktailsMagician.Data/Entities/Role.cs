using Microsoft.AspNetCore.Identity;
using System;

namespace CocktailsMagician.Data.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}
