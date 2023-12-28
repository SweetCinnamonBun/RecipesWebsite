using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipesAPI.Data;
using RecipesAPI.Models.Domain;
using RecipesAPI.Repositories.Directions;

namespace RecipesAPI.Repositories.Directions
{
    public class SQLDirectionsRepository : IDirectionsRepository
    {
        private readonly RecipesDbContext dbContext;

        public SQLDirectionsRepository(RecipesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Direction> CreateAsync(Direction direction)
        {
            await dbContext.Directions.AddAsync(direction);
            await dbContext.SaveChangesAsync();
            return direction;
        }

        public async Task<Direction?> DeleteAsync(Guid id)
        {
            var requestedDirection = await dbContext.Directions.FirstOrDefaultAsync(x => x.Id == id);

            if (requestedDirection == null)
            {
                return null;
            }

            dbContext.Directions.Remove(requestedDirection);
            await dbContext.SaveChangesAsync();

            return requestedDirection;
        }

        public async Task<List<Direction>> GetAllAsync()
        {
            return await dbContext.Directions.ToListAsync();
        }

        public async Task<Direction?> GetByIdAsync(Guid id)
        {
            var requestedDirection = await dbContext.Directions.FirstOrDefaultAsync(x => x.Id == id);

            if (requestedDirection == null)
            {
                return null;
            }

            return requestedDirection;
        }

        public async Task<Direction?> UpdateAsync(Guid id, Direction direction)
        {
            var requestedDirection = await dbContext.Directions.FirstOrDefaultAsync(x => x.Id == id);

            if (requestedDirection == null)
            {
                return null;
            }

            requestedDirection.StepNumber = direction.StepNumber;
            requestedDirection.Description = direction.Description;

            await dbContext.SaveChangesAsync();

            return requestedDirection;
        }
    }
}