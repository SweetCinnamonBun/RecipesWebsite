using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipesAPI.Models.Domain;

namespace RecipesAPI.Repositories.Ingredients
{
    public interface IIngredientsRepository
    {
        Task<Ingredient> CreateAsync(Ingredient ingredient);
        Task<List<Ingredient>> GetAllAsync();
        Task<Ingredient?> GetByIdAsync(Guid id);

        Task<Ingredient?> UpdateAsync(Guid id, Ingredient ingredient);

        Task<Ingredient?> DeleteAsync(Guid id);
    }
}