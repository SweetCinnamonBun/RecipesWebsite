using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipesAPI.Models.Domain;

namespace RecipesAPI.Repositories.Recipes
{
    public interface IRecipeRepository
    {
        Task<List<Recipe>> GetAllAsync();

        Task<Recipe?> GetByIdAsync(Guid id);

        Task<Recipe> CreateAsync(Recipe recipe);

        Task<Recipe?> UpdateAsync(Guid id, Recipe recipe);

        Task<Recipe?> DeleteAsync(Guid id);
    }
}