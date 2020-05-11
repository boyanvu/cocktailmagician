using CocktailsMagician.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailsMagician.Services.DTO_s
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool isBanned { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DeletedOn { get; set; }
        public ICollection<BarReview> BarReviews { get; set; }
        public ICollection<BarReviewLike> BarReviewLikes { get; set; }
        public ICollection<CocktailReview> CocktailReviews { get; set; }
        public ICollection<CocktailReviewLike> CocktailReviewLikes { get; set; }
    }
}
