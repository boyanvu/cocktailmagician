using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CocktailsMagician.Models;
using CocktailsMagician.Services.Contracts;
using CocktailsMagician.Mappers;
using CocktailsMagician.Helpers;

namespace CocktailsMagician.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBarService _barService;
        private readonly ICocktailService _cocktailService;

        public HomeController(ILogger<HomeController> logger, IBarService barService, ICocktailService cocktailService)
        {
            _logger = logger;
            _barService = barService;
            _cocktailService = cocktailService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["imgPath"] = ImagesPath.ImgsPath;
            var cocktailDtos = await _cocktailService.GetAllCocktailsForHomePage();
            var cocktailsVM = cocktailDtos.Select(c => c.CocktailDTOMapToVM()).ToList();
            var barDTOs = await _barService.GetAllBarsForHomePage();
            var barsVM = barDTOs.Select(b => b.BarDTOtoVM()).ToList();

            var homePageVM = new HomeViewModel(barsVM, cocktailsVM);
            return View(homePageVM); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult NotFound()
        {
            return View();
        }
    }
}
