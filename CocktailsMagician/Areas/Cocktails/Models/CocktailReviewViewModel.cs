using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailsMagician.Areas.Cocktails.Models
{
    public class CocktailReviewViewModel
    {
        public Guid Id { get; set; }
        public Guid CocktailId { get; set; }
        public String CocktailName { get; set; }
        public Guid UserId { get; set; }
        public String UserName { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public bool isLiked { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime ReviewedOn { get; set; }
        //public ICollection<CocktailReviewLike> CocktailReviewLikes { get; set; }
    }
}
