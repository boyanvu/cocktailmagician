using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailsMagician.Data.Entities
{
    public class BarReviewLike
    {
        public Guid BarId { get; set; }
        public Bar Bar { get; set; }
        public Guid UserReviewId { get; set; }
        public User UserReview { get; set; }

        public Guid UserLikeId { get; set; }
        public User UserLike { get; set; }
        public bool IsInappropriate { get; set; }
    }
}
