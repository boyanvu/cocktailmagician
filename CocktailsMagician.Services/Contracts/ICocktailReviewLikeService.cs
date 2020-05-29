using CocktailsMagician.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsMagician.Services.Contracts
{
    public interface ICocktailReviewLikeService
    {
        Task<CocktailReviewLikeDTO> AddCocktailReviewLike(Guid cocktailReviewId, string username);
        Task<CocktailReviewLikeDTO> RemoveCocktailReviewLike(Guid cocktailReviewId, string username);
        Task<IEnumerable<CocktailReviewLikeDTO>> GetAllCocktailReviewLikes();
        Task<IEnumerable<CocktailReviewLikeDTO>> GetAllSpecificCocktailReviewLikes(Guid cocktailId);
    }
}
