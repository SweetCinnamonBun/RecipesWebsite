using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipesAPI.Models.Domain;

namespace RecipesAPI.Repositories.ShoppingLists
{
    public interface IShoppingListRepository
    {
        Task<ShoppingList> CreateAsync(ShoppingList shoppingList);
        Task<List<ShoppingList>> GetAllAsync();
        // Task<ShoppingList?> GetByIdAsync(Guid id);

        Task<ShoppingList?> UpdateAsync(Guid id, ShoppingList shoppingList);

        Task<ShoppingList?> DeleteAsync(Guid id);
    }
}