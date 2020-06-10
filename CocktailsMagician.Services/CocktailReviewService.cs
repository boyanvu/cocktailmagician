using CocktailsMagician.Data;
using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services.Contracts;
using CocktailsMagician.Services.DTO_s;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CocktailsMagician.Services.Mappers;

namespace CocktailsMagician.Services
{
    public class CocktailReviewService : ICocktailReviewService
    {
        private readonly CMContext _cmContext;
        public CocktailReviewService(CMContext context)
        {
            this._cmContext = context;
        }

        public async Task<CocktailReviewDTO> CreateCocktailReview(string cocktailName, string userName, int rating, string comment)
        {

            var user = await _cmContext.Users.FirstOrDefaultAsync(u => u.UserName == userName);

            if (user == null)
            {
                throw new ArgumentNullException("User is null!");
            }

            var cocktail = await _cmContext.Cocktails
                .Where(c => c.UnlistedOn == null)
                .FirstOrDefaultAsync(c => c.Name == cocktailName);

            if (cocktail == null)
            {
                throw new ArgumentNullException("Cocktail is null!");
            }


            if (rating < 1 || rating > 5)
            {
                throw new ArgumentOutOfRangeException("Rating is out of range!");
            }

            var cocktailReview = new CocktailReview
            {
                UserId = user.Id,
                CocktailId = cocktail.Id,
                Rating = rating,
                Comment = comment,
                ReviewedOn = DateTime.UtcNow
            };
            
            try
            {
                cocktail.AvgRating = await this.CalculateAvgRating(cocktail.Id, rating);
                await _cmContext.CocktailReviews.AddAsync(cocktailReview);
                await _cmContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Cannot add into database!");
            }

            var cocktailReviewDTO = cocktailReview.CocktailMapReviewDTO();

            return cocktailReviewDTO;
        }

        public async Task<IEnumerable<CocktailReviewDTO>> GetAllSpecificCocktailReviews(Guid cocktailId)
        {
            return await _cmContext.CocktailReviews
                .Where(cr => cr.CocktailId == cocktailId)
                .Include(cr => cr.User)
                .Include(cr => cr.Cocktail)
                .Select(cr => cr.CocktailMapReviewDTO())
                .ToListAsync();
        }

        public async Task<bool> HasAlreadyReviewedAsync(Guid cocktailId, Guid userId)
        {
            var hasReviewed = await _cmContext.CocktailReviews.AnyAsync(br => br.CocktailId == cocktailId
                                                                     && br.UserId == userId
                                                                     && br.DeletedOn == null);
            return hasReviewed;
        }

        private async Task<double> CalculateAvgRating(Guid cocktailId, int ratingToAdd = 0)
        {
            var cocktailReviews = await _cmContext.CocktailReviews.Where(cr => cr.CocktailId == cocktailId && cr.DeletedOn == null).ToListAsync();
            var nrOfReviews = cocktailReviews.Count();
            var sumOfRratings = cocktailReviews.Sum(br => br.Rating);
            if (nrOfReviews == 0)
            {
                return Convert.ToDouble(ratingToAdd);
            }
            else
            {
                var avgRating = (sumOfRratings + ratingToAdd) / (nrOfReviews + (ratingToAdd != 0 ? 1 : 0));
                return Convert.ToDouble(avgRating);
            }
        }
    }
}
