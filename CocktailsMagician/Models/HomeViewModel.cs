using CocktailsMagician.Areas.Bars.Models;
using CocktailsMagician.Areas.Cocktails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailsMagician.Models
{
    public class HomeViewModel
    {
        public HomeViewModel(ICollection<BarViewModel> bars,
            ICollection<CocktailViewModel> cocktails)
        {
            this.Bars = bars;
            this.Cocktails = cocktails;     
        }
        public ICollection<BarViewModel> Bars { get; set; }
        public ICollection<CocktailViewModel> Cocktails { get; set; }
    }
}
