﻿using CocktailsMagician.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsMagician.Services.Contracts
{
    public interface ICocktailReviewService
    {
        Task<CocktailReviewDTO> CreateCocktailReview(string cocktailName, string userName, int rating, string comment);
        Task<IEnumerable<CocktailReviewDTO>> GetAllSpecificCocktailReviews(Guid cocktailId);
    }
}
