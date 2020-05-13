using CocktailsMagician.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsMagician.Services.Contracts
{
    public interface IBarReviewService
    {
        Task<BarReviewDTO> GetBarReviewAsync(Guid id);
        Task<IEnumerable<BarReviewDTO>> GetAllBarReviewsAsync();
        Task<BarReviewDTO> CreateBarReviewAsync(Guid barId, Guid userId, int rating, string comment);
        Task<BarReviewDTO> UpdateBarReviewAsync(Guid reviewId, int rating, string comment);
        Task<bool> DeleteBarReviewAsync(Guid reviewId);
    }
}
