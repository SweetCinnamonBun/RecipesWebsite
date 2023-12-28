using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using RecipesAPI.Data;
using RecipesAPI.Models.Domain;

namespace RecipesAPI.Repositories.ShoppingLists
{
    public class SQLShoppingListRepository : IShoppingListRepository
    {
        private readonly RecipesDbContext dbContext;

        public SQLShoppingListRepository(RecipesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ShoppingList> CreateAsync(ShoppingList shoppingList)
        {
            await dbContext.ShoppingLists.AddAsync(shoppingList);
            await dbContext.SaveChangesAsync();
            return shoppingList;
        }

        public async Task<ShoppingList?> DeleteAsync(Guid id)
        {
            var response = await dbContext.ShoppingLists.FirstOrDefaultAsync(x => x.Id == id);

            if (response == null)
            {
                return null;
            }

            dbContext.Remove(response);
            await dbContext.SaveChangesAsync();

            return response;
        }

        public async Task<List<ShoppingList>> GetAllAsync()
        {
            var shoppingLists = await dbContext.ShoppingLists.Include(x => x.Items).ToListAsync();
            return shoppingLists;
        }

        // public Task<ShoppingList?> GetByIdAsync(Guid id)
        // {
        //     throw new NotImplementedException();
        // }

        public async Task<ShoppingList?> UpdateAsync(Guid id, ShoppingList shoppingList)
        {
            var response = await dbContext.ShoppingLists.FirstOrDefaultAsync(x => x.Id == id);

            if (response == null)
            {
                return null;
            }

            response.Name = shoppingList.Name;
            response.Items = shoppingList.Items;

            await dbContext.SaveChangesAsync();

            return response;

        }
    }
}