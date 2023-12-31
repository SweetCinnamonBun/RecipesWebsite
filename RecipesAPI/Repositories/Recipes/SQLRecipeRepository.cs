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

        // public async Task<Recipe> CreateAsync(Recipe recipe)
        // {
        //     // Assuming recipe.Categories is not null and has at least one category
        //     var categoryName = recipe.Categories[0].Name.ToLower();

        //     var category = await dbContext.Categories.SingleOrDefaultAsync(x => x.Name.ToLower() == categoryName);

        //     if (category == null)
        //     {
        //         // Handle the case where the category doesn't exist
        //         return null;
        //     }

        //     // Attach or add the category to the context based on its state
        //     if (dbContext.Entry(category).State == EntityState.Detached)
        //     {
        //         dbContext.Categories.Attach(category);
        //     }

        //     // Set the state of the category to Unchanged
        //     dbContext.Entry(category).State = EntityState.Unchanged;

        //     // Add the category to the recipe
        //     recipe.Categories.Add(category);

        //     // Add the recipe to the context
        //     await dbContext.Recipes.AddAsync(recipe);

        //     // Save changes
        //     await dbContext.SaveChangesAsync();

        //     return recipe;
        // }

        public async Task<Recipe?> DeleteAsync(Guid id)
        {
            var deletedIngredient = await dbContext.Recipes.FirstOrDefaultAsync(x => x.Id == id);

            if (deletedIngredient == null)
            {
                return null;
            }

            dbContext.Recipes.Remove(deletedIngredient);
            await dbContext.SaveChangesAsync();
            return deletedIngredient;
        }

        public async Task<List<Recipe>> GetAllAsync()
        {
            return await dbContext.Recipes.Include(x => x.Comments).Include(x => x.Categories).
                Include(x => x.Ingredients).
                Include(x => x.Directions).
                Include(x => x.ShoppingList).
                ThenInclude(x => x.Items).ToListAsync();
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