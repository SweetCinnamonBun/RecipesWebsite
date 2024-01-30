using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipesAPI.Data;
using RecipesAPI.Models.Domain;

namespace RecipesAPI.Repositories.Ratings
{
    public class SQLRatingsRepository : IRatingsRepository
    {
        private readonly RecipesDbContext dbContext;

        public SQLRatingsRepository(RecipesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Rating> CreateAsync(Rating rating)
        {
            await dbContext.Ratings.AddAsync(rating);
            await dbContext.SaveChangesAsync();
            return rating;
        }

        public async Task<Rating?> DeleteAsync(Guid id)
        {
            var rating = await dbContext.Ratings.FirstOrDefaultAsync(x => x.Id == id);

            if (rating == null)
            {
                return null;
            }

            dbContext.Remove(rating);
            await dbContext.SaveChangesAsync();
            return rating;
        }

        public async Task<List<Rating>> GetAllAsync()
        {
            var ratings = await dbContext.Ratings.ToListAsync();
            return ratings;
        }

        public async Task<Rating?> GetByIdAsync(Guid id)
        {
            var rating = await dbContext.Ratings.FirstOrDefaultAsync(x => x.Id == id);

            if (rating == null)
            {
                return null;
            }

            return rating;
        }

        public async Task<Rating?> UpdateAsync(Guid id, Rating rating)
        {
            var updateRating = await dbContext.Ratings.FirstOrDefaultAsync(x => x.Id == id);

            if (updateRating == null)
            {
                return null;
            }

            updateRating.Value = rating.Value;

            return updateRating;
        }

        public async Task<List<Rating>> GetUserRatings(string id)
        {


            var userRatings = await dbContext.Ratings.Where(x => x.UserProfileId == id).ToListAsync();
            return userRatings;
        }
    }
}