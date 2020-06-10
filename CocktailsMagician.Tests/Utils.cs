using CocktailsMagician.Data;
using Microsoft.EntityFrameworkCore;

namespace CocktailsMagician.Tests
{
    public class Utils
    {
        public static DbContextOptions<CMContext> GetOptions(string databaseName)
        {
            return new DbContextOptionsBuilder<CMContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;
        }
    }
}
