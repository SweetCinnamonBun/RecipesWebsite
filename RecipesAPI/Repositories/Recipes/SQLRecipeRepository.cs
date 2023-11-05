using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipesAPI.Data;
using RecipesAPI.Models.Domain;

namespace RecipesAPI.Repositories.Recipes
{
    public class SQLRecipeRepository : IRecipeRepository
    {

        private readonly RecipesDbContext dbContext;
        public SQLRecipeRepository(RecipesDbContext dbContext)
        {
            this.dbContext = dbContext;

        }

        public async Task<Recipe> CreateAsync(Recipe recipe)
        {
            await dbContext.Recipes.AddAsync(recipe);
            await dbContext.SaveChangesAsync();
            return recipe;
        }

        public async Task<List<Recipe>> GetAllAsync()
        {
            return await dbContext.Recipes.Include(x => x.Ingredients).ToListAsync();
        }

        public async Task<Recipe?> GetByIdAsync(Guid id)
        {
            return await dbContext.Recipes.Include(x => x.Ingredients).FirstOrDefaultAsync(recipe => recipe.Id == id);
        }

        public async Task<Recipe?> UpdateAsync(Guid id, Recipe recipe)
        {
            var requestedRecipe = await dbContext.Recipes.FirstOrDefaultAsync(x => x.Id == id);

            if (requestedRecipe == null)
            {
                return null;
            }

            requestedRecipe.Name = recipe.Name;
            requestedRecipe.CookingTime = recipe.CookingTime;
            requestedRecipe.Ingredients = recipe.Ingredients;
            requestedRecipe.Categories = recipe.Categories;
            requestedRecipe.Directions = recipe.Directions;

            await dbContext.SaveChangesAsync();
            return requestedRecipe;
        }
    }
}