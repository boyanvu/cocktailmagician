using CocktailsMagician.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsMagician.Services.Contracts
{
    public interface IBarReviewLikeService
    {
        Task<bool> AddBarReviewLikeAsync(Guid reviewId, Guid userId);
        Task<bool> RemoveBarReviewLikeAsync(Guid reviewId, Guid userId);    
        Task<BarReviewLike> MarkInapproprBarReviewLike(Guid reviewId, Guid userId);
    }
}
