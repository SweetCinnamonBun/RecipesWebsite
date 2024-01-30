using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipesAPI.Models.Domain;

namespace RecipesAPI.Repositories.Ratings
{
    public interface IRatingsRepository
    {
        Task<Rating> CreateAsync(Rating rating);
        Task<List<Rating>> GetAllAsync();
        Task<Rating?> GetByIdAsync(Guid id);

        Task<Rating?> UpdateAsync(Guid id, Rating rating);

        Task<Rating?> DeleteAsync(Guid id);

        Task<List<Rating>> GetUserRatings(string id);
    }
}