using CocktailsMagician.Data.Entities;
using System;
using System.Collections.Generic;

namespace CocktailsMagician.Services.DTO_s
{
    public class BarReviewDTO
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
        public ICollection<BarReviewLike> BarReviewLikes { get; set; }
    }
}
