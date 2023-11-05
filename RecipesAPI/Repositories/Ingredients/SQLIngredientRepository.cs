using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipesAPI.Data;
using RecipesAPI.Models.Domain;

namespace RecipesAPI.Repositories.Ingredients
{
    public class SQLIngredientRepository : IIngredientsRepository
    {
        private readonly RecipesDbContext dbContext;
        public SQLIngredientRepository(RecipesDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        public async Task<Ingredient> CreateAsync(Ingredient ingredient)
        {
            await dbContext.Ingredients.AddAsync(ingredient);
            await dbContext.SaveChangesAsync();
            return ingredient;
        }

        public async Task<Ingredient?> DeleteAsync(Guid id)
        {
            var ingredient = await dbContext.Ingredients.FirstOrDefaultAsync(i => i.Id == id);
            if (ingredient == null)
            {
                return null;
            }

            dbContext.Ingredients.Remove(ingredient);
            await dbContext.SaveChangesAsync();

            return ingredient;
        }

        public Task<List<Ingredient>> GetAllAsync()
        {
            return dbContext.Ingredients.ToListAsync();
        }

        public async Task<Ingredient?> GetByIdAsync(Guid id)
        {
            var requestedIngredient = await dbContext.Ingredients.FirstOrDefaultAsync(i => i.Id == id);

            if (requestedIngredient == null)
            {
                return null;
            }

            return requestedIngredient;
        }

        public async Task<Ingredient?> UpdateAsync(Guid id, Ingredient ingredient)
        {
            var requestedIngredient = await dbContext.Ingredients.FirstOrDefaultAsync(i => i.Id == id);

            if (requestedIngredient == null)
            {
                return null;
            }

            requestedIngredient.Name = ingredient.Name;
            requestedIngredient.Amount = ingredient.Amount;

            await dbContext.SaveChangesAsync();

            return requestedIngredient;
        }
    }
}