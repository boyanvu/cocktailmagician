using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocktailsMagician.Data;
using CocktailsMagician.Services.Contracts;
using CocktailsMagician.Services.DTO_s;
using Microsoft.EntityFrameworkCore;
using CocktailsMagician.Services.Mappers;
using CocktailsMagician.Data.Entities;

namespace CocktailsMagician.Services.Services
{
    public class BarReviewService : IBarReviewService
    {
        private readonly CMContext _cmContext;
        public BarReviewService(CMContext cmContext)
        {
            this._cmContext = cmContext;
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

        public IQueryable<BarReview> GetBarReviewsAsync(Guid barId,Guid userId)
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

        public async Task<BarReviewDTO> GetBarReviewAsync(Guid barReviewId)
        {
            var barReview = await _cmContext.BarReviews.FindAsync(barReviewId);
            if (barReview == null)
            {
                throw new ArgumentNullException("The review is missing.");
            }
            var barReviewDTO = barReview.BarMapReviewDTO();
            return barReviewDTO;
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
            var barReviewIfExists = await this.GetBarReviewsAsync(barId, userId).Where(br => br.DeletedOn == null).FirstOrDefaultAsync();
            if (barReviewIfExists != null)
            {
                throw new ArgumentException("This bar has already been reviewed by the user");
            }
            
            var bar = await _cmContext.Bars
                .Where(b => b.UnlistedOn == null)
                .FirstOrDefaultAsync(b => b.Id == barId);

            if (bar==null)
            {
                throw new ArgumentNullException("Bar is not available.");
            }
            var user = await _cmContext.Users
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new ArgumentNullException("User is not available");
            }
            if (rating<1 || rating>5)
            {
                throw new ArgumentOutOfRangeException("Rating must be bewtwee 1 and 5.");
            }
            var barReview = new BarReview();
            barReview.BarId = barId;
            barReview.UserId = userId;
            barReview.Rating = rating;
            barReview.Comment = comment;
            barReview.ReviewedOn = DateTime.UtcNow;

            _cmContext.BarReviews.Add(barReview);
            await _cmContext.SaveChangesAsync();

            var barReviewDTO = await this.GetBarReviewsAsync(barId, userId)
                .Select(br=>br.BarMapReviewDTO()).FirstOrDefaultAsync();

            return barReviewDTO;
        }
        public Task<BarReviewDTO> UpdateBarReviewAsync(Guid reviewId, int rating, string comment)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteBarReviewAsync(Guid reviewId)
        {
            throw new NotImplementedException();
        }
    }
}
