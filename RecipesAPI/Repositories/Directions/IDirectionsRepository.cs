using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipesAPI.Models.Domain;

namespace RecipesAPI.Repositories.Directions
{
    public interface IDirectionsRepository
    {
        Task<Direction> CreateAsync(Direction direction);
        Task<List<Direction>> GetAllAsync();
        Task<Direction?> GetByIdAsync(Guid id);

        Task<Direction?> UpdateAsync(Guid id, Direction direction);

        Task<Direction?> DeleteAsync(Guid id);
    }
}