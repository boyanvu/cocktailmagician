using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services.DTO_s;

namespace CocktailsMagician.Services.Mappers
{
    public static class UserMapperDTO
    {
        public static UserDTO UserMapToDTO(this User user)
        {
            var userDTO = new UserDTO();
            userDTO.Id = user.Id;
            userDTO.UserName = user.UserName;
            userDTO.FirstName = user.FirstName;
            userDTO.LastName = user.LastName;
            userDTO.Email = user.Email;
            userDTO.BarReviews = user.BarReviews;
            userDTO.BarReviewLikes = user.BarReviewLikes;
            userDTO.CocktailReviews = user.CocktailReviews;
            userDTO.CocktailReviewLikes = user.CocktailReviewLikes;

            return userDTO;

        }
    }
}
