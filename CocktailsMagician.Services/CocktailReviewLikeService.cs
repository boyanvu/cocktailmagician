using CocktailsMagician.Data;
using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services.Contracts;
using CocktailsMagician.Services.DTO_s;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CocktailsMagician.Services.Mappers;
using System.Linq;

namespace CocktailsMagician.Services
{
    public class CocktailReviewLikeService : ICocktailReviewLikeService
    {
        private readonly CMContext _cmContext;
        public CocktailReviewLikeService(CMContext context)
        {
            this._cmContext = context;
        }

        public async Task<CocktailReviewLikeDTO> AddCocktailReviewLike(Guid cocktailReviewId, string userName)
        {
            var cReview = await _cmContext.CocktailReviews
                .FirstOrDefaultAsync(cr => cr.Id == cocktailReviewId);

            if(cReview == null)
            {
                throw new InvalidOperationException("Cocktail review not found!");
            }

            var user = await _cmContext.Users
            .FirstOrDefaultAsync(u => u.UserName == userName);

            if (user == null)
            {
                throw new InvalidOperationException("User not found!");
            }


            var cocktailReviewLike = new CocktailReviewLike
            {
                CocktailReviewId = cReview.Id,
                UserId = user.Id,
                IsLiked = true
            };

            try
            {
                await _cmContext.CocktailReviewLikes.AddAsync(cocktailReviewLike);
                await _cmContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Cannot add into database!");
            }

            var cocktailReviewLikeDTO = cocktailReviewLike.CocktailReviewLikeMapToDTO();

            return cocktailReviewLikeDTO;
        }

        public async Task<IEnumerable<CocktailReviewLikeDTO>> GetAllCocktailReviewLikes()
        {
            return await _cmContext.CocktailReviewLikes
                .Include(cr => cr.User)
                .Select(cr => cr.CocktailReviewLikeMapToDTO())
                .ToListAsync();
        }
    }
}
