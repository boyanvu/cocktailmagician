using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsMagician.Services.Contracts
{
    public interface IBarReviewService
    {
        Task<BarReviewDTO> GetBarReviewByIdAsync(Guid id);
        IQueryable<BarReview> GetBarReviewsAsync(Guid barId, Guid userId);
        Task<IEnumerable<BarReviewDTO>> GetAllBarReviewsAsync();
        Task<BarReviewDTO> CreateBarReviewAsync(Guid barId, Guid userId, int rating, string comment);
        Task<BarReviewDTO> UpdateBarReviewAsync(Guid reviewId, int? rating, string comment);
        Task<bool> DeleteBarReviewAsync(Guid reviewId);
        Task<bool> HasAlreadyReviewedAsync(Guid barId, Guid userId);
    }
}
