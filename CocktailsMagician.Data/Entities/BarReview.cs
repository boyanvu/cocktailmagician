using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailsMagician.Data.Entities
{
    public class BarReview
    {
        public int BarId { get; set; }
        public Bar Bar { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
