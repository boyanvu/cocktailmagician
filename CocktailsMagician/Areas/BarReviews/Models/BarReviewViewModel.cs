using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailsMagician.Areas.BarReviews.Models
{
    public class BarReviewViewModel
    {
        public Guid Id { get; set; }
        public Guid BarId { get; set; }
        public String BarName { get; set; }
        public Guid UserId { get; set; }
        public String UserName { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime ReviewedOn { get; set; }
        //public ICollection<BarReviewLike> BarReviewLikes { get; set; }
    }
}
