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
                throw new ArgumentNullException("Cocktail review not found!");
            }

            var user = await _cmContext.Users
            .FirstOrDefaultAsync(u => u.UserName == userName);

            if (user == null)
            {
                throw new ArgumentNullException("User not found!");
            }

            var cocktailReviewLike = await _cmContext.CocktailReviewLikes
             .FirstOrDefaultAsync(cr => cr.CocktailReviewId == cocktailReviewId && cr.UserId == user.Id);

            if(cocktailReviewLike == null)
            {
                var cocktailReviewLikeNew = new CocktailReviewLike
                {
                    CocktailReviewId = cReview.Id,
                    UserId = user.Id,
                    IsLiked = true
                };

                try
                {
                    await _cmContext.CocktailReviewLikes.AddAsync(cocktailReviewLikeNew);
                    await _cmContext.SaveChangesAsync();

                    var cocktailReviewLikeNewDTO = cocktailReviewLikeNew.CocktailReviewLikeMapToDTO();
                    return cocktailReviewLikeNewDTO;
                }
                catch (Exception)
                {
                    throw new InvalidOperationException("Cannot add into database!");
                }
            }
            else
            {
                cocktailReviewLike.IsLiked = true;
                await _cmContext.SaveChangesAsync();
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

        public async Task<CocktailReviewLikeDTO> RemoveCocktailReviewLike(Guid cocktailReviewId, string userName)
        {
            var cReview = await _cmContext.CocktailReviews
               .FirstOrDefaultAsync(cr => cr.Id == cocktailReviewId);

            if (cReview == null)
            {
                throw new ArgumentNullException("Cocktail review not found!");
            }

            var user = await _cmContext.Users
            .FirstOrDefaultAsync(u => u.UserName == userName);

            if (user == null)
            {
                throw new ArgumentNullException("User not found!");
            }


            var cocktailReviewLike = await _cmContext.CocktailReviewLikes
               .FirstOrDefaultAsync(cr => cr.CocktailReviewId == cocktailReviewId && cr.UserId == user.Id);

            if(cocktailReviewLike == null)
            {
                throw new ArgumentNullException("Cocktail Review like not found!");
            }
            cocktailReviewLike.IsLiked = false;

            try
            {              
                await _cmContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Cannot add into database!");
            }

            var cocktailReviewLikeDTO = cocktailReviewLike.CocktailReviewLikeMapToDTO();

            return cocktailReviewLikeDTO;
        }


        public async Task<IEnumerable<CocktailReviewLikeDTO>> GetAllSpecificCocktailReviewLikes(Guid cocktailId)
        {
            var cocktailReviews =  await _cmContext.CocktailReviews
                .Where(cr => cr.CocktailId == cocktailId)
                .Include(cr => cr.User)
                .Include(cr => cr.Cocktail)
                .Select(cr => cr.CocktailMapReviewDTO())
                .ToListAsync();

            var allCocktailReviewLikes =  await _cmContext.CocktailReviewLikes
               .Include(cr => cr.User)
               .Select(cr => cr.CocktailReviewLikeMapToDTO())
               .ToListAsync();

            List<CocktailReviewLikeDTO> specificCocktailRL = new List<CocktailReviewLikeDTO>();

            foreach (var reviewLike in allCocktailReviewLikes)
            {
                foreach (var review in cocktailReviews)
                {
                    if (reviewLike.CocktailReviewId == review.Id)
                    {
                        specificCocktailRL.Add(reviewLike);
                    }
                }         
            }

            return specificCocktailRL;
        }
    }
}
