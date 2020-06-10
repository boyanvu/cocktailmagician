using System;
using System.Collections.Generic;

namespace CocktailsMagician.Data.Entities
{
    public class BarReview
    {
        public Guid Id { get; set; }
        public Guid BarId { get; set; }
        public Bar Bar { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime ReviewedOn { get; set; }
        public ICollection<BarReviewLike> BarReviewLikes { get; set; }
    }
}
