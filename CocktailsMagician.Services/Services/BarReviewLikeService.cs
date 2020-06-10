using CocktailsMagician.Data;
using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailsMagician.Services.Services
{
    public class BarReviewLikeService : IBarReviewLikeService
    {
        private readonly CMContext _cmContext;
        public BarReviewLikeService(CMContext cmContext)
        {
            this._cmContext = cmContext;
        }

        public async Task<bool> AddBarReviewLikeAsync(Guid reviewId, Guid userId)
        {
            var reviewExists = await _cmContext.BarReviews.AnyAsync(br => br.Id == reviewId && br.DeletedOn == null);
            if (!reviewExists)
            {
                throw new ArgumentNullException("Review does not exist or it is deleted.");
            }
            var barReviewLike = await _cmContext.BarReviewLikes
                                    .Where(brl => brl.BarReviewId == reviewId && brl.UserId == userId)
                                    .FirstOrDefaultAsync();

            if (barReviewLike != null)
            {
                barReviewLike.IsLiked = true;
            }
            else
            {
                var barReviewLikeNew = new BarReviewLike()
                {
                    BarReviewId = reviewId,
                    UserId = userId,
                    IsLiked = true
                };
                _cmContext.BarReviewLikes.Add(barReviewLikeNew);
            }
            try
            {
                await _cmContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }

        public async Task<bool> RemoveBarReviewLikeAsync(Guid reviewId, Guid userId)
        {
            var reviewExists = await _cmContext.BarReviews.AnyAsync(br => br.Id == reviewId && br.DeletedOn == null);
            if (!reviewExists)
            {
                throw new ArgumentNullException("Review does not exist or it is deleted.");
            }
            var barReviewLike = await _cmContext.BarReviewLikes
                                    .Where(brl => brl.BarReviewId == reviewId && brl.UserId == userId)
                                    .FirstOrDefaultAsync();

            if (barReviewLike == null)
            {
                throw new ArgumentNullException("There's no like for the review to be removed.");
            }
            barReviewLike.IsLiked = false;

            try
            {
                await _cmContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }

        public Task<BarReviewLike> MarkInapproprBarReviewLike(Guid reviewId, Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
