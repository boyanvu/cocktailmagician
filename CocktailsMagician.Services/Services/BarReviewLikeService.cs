using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsMagician.Services.Services
{
    public class BarReviewLikeService : IBarReviewLikeService
    {
        public Task<BarReviewLike> AddBarReviewLike(Guid reviewId, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<BarReviewLike> MarkInapproprBarReviewLike(Guid reviewId, Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
