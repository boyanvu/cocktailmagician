using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CocktailsMagician.Data;
using CocktailsMagician.Services.Contracts;
using CocktailsMagician.Services.DTO_s;
using Microsoft.EntityFrameworkCore;
using CocktailsMagician.Services.Mappers;
using CocktailsMagician.Data.Entities;
using Microsoft.AspNetCore.Identity;


namespace CocktailsMagician.Services.Services
{
    public class BarReviewService : IBarReviewService
    {
        private readonly CMContext _cmContext;
        private readonly UserManager<User> userManager;
        public BarReviewService(CMContext cmContext, UserManager<User> userManager)
        {
            this._cmContext = cmContext;
            this.userManager = userManager;
        }
        public async Task<BarReviewDTO> GetBarReviewByIdAsync(Guid barReviewId)
        {
            var barReview = await _cmContext.BarReviews.FindAsync(barReviewId);
            if (barReview == null)
            {
                throw new ArgumentNullException("The review is missing.");
            }
            var barReviewDTO = barReview.BarMapReviewDTO();
            return barReviewDTO;
        }

        public IQueryable<BarReview> GetBarReviewsAsync(Guid barId, Guid userId)
        {
            var barReviewQry = _cmContext.BarReviews as IQueryable<BarReview>;
            if (barId != null)
            {
                barReviewQry = barReviewQry.Where(br => br.BarId == barId);
            }
            if (userId != null)
            {
                barReviewQry = barReviewQry.Where(br => br.UserId == userId);
            }
            return barReviewQry;
        }

        public async Task<IEnumerable<BarReviewDTO>> GetAllBarReviewsAsync()
        {
            var barReviews = await _cmContext.BarReviews
                .Select(br => br.BarMapReviewDTO())
                .ToListAsync();

            return barReviews;
        }
        public async Task<BarReviewDTO> CreateBarReviewAsync(Guid barId, Guid userId, int rating, string comment)
        {
            var barReviewExists = await _cmContext.BarReviews.AnyAsync(br=> br.UserId == userId && br.BarId == barId && br.DeletedOn == null);

            if (barReviewExists)
            {
                throw new ArgumentException("This bar has already been reviewed by the user");
            }

            var bar = await _cmContext.Bars.Where(b => b.Id == barId && b.UnlistedOn == null).FirstOrDefaultAsync();

            if (bar == null)
            {
                throw new ArgumentNullException("Bar is not available.");
            }

            var userExists = await _cmContext.Users.AnyAsync(u => u.Id == userId && u.DeletedOn == null);

            if (!userExists)
            {
                throw new ArgumentNullException("User is not available");
            }
            if (rating < 1 || rating > 5)
            {
                throw new ArgumentOutOfRangeException("Rating must be bewtween 1 and 5.");
            }
            var barReview = new BarReview();
            barReview.BarId = barId;
            barReview.UserId = userId;
            barReview.Rating = rating;
            barReview.Comment = comment;
            barReview.ReviewedOn = DateTime.UtcNow;
            try
            {
                bar.AvgRating = await this.CalculateAvgRating(barId, rating);
                _cmContext.BarReviews.Add(barReview);
                await _cmContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            var barReviewDTO = barReview.BarMapReviewDTO();

            return barReviewDTO;
        }

        private async Task<double> CalculateAvgRating(Guid barId, int ratingToAdd = 0)
        {
            var barReviews = await _cmContext.BarReviews.Where(br => br.BarId == barId && br.DeletedOn == null).ToListAsync();
            var nrOfReviews = barReviews.Count();
            var sumOfRratings = barReviews.Sum(br=>br.Rating);
            if (nrOfReviews==0)
            {
                return Convert.ToDouble(ratingToAdd);
            }
            else
            {
                var avgRating = (sumOfRratings + ratingToAdd) / (nrOfReviews + (ratingToAdd != 0 ? 1 : 0));
                return Convert.ToDouble(avgRating);
            }
        }
        public async Task<BarReviewDTO> UpdateBarReviewAsync(Guid reviewId, int? rating, string comment)
        {
            var barReview = await _cmContext.BarReviews.FindAsync(reviewId);
            if (barReview == null)
            {
                throw new ArgumentException("Missing bar review");
            }
            if (rating != null)
            {
                if (rating < 1 || rating > 5)
                {
                    throw new ArgumentOutOfRangeException("Rating must be bewtween 1 and 5.");
                }
                barReview.Rating = (int)rating;
            }
            barReview.Comment = comment;

            try
            {
                await _cmContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return barReview.BarMapReviewDTO();
        }
        public Task<bool> DeleteBarReviewAsync(Guid reviewId)
        {
            throw new NotImplementedException();
        }
    }
}