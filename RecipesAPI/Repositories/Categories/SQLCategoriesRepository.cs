using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipesAPI.Data;
using RecipesAPI.Models.Domain;

namespace RecipesAPI.Repositories.Categories
{
    public class SQLCategoriesRepository : ICategoriesRepository
    {
        private readonly RecipesDbContext dbContext;

        public SQLCategoriesRepository(RecipesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Category> CreateAsync(Category category)
        {
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> DeleteAsync(Guid id)
        {
            var response = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (response == null)
            {
                return null;
            }

            dbContext.Remove(response);
            await dbContext.SaveChangesAsync();

            return response;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            var categories = await dbContext.Categories.ToListAsync();
            return categories;
        }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            var category = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
            {
                return null;
            }

            return category;
        }

        public async Task<Category?> UpdateAsync(Guid id, Category category)
        {
            var categoryUpdate = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (categoryUpdate == null)
            {
                return null;
            }

            categoryUpdate.Name = category.Name;
            await dbContext.SaveChangesAsync();
            return categoryUpdate;
        }
    }
}