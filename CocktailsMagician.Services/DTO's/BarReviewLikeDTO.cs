using CocktailsMagician.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailsMagician.Services.DTO_s
{
    public class BarReviewLikeDTO
    {
        public Guid BarReviewId { get; set; }
        public BarReview BarReview { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public bool IsLiked { get; set; }
        public bool IsInappropriate { get; set; }
    }
}
