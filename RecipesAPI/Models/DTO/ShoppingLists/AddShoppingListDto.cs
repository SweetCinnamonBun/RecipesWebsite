using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.Models.DTO.ShoppingLists
{
    public class AddShoppingListDto
    {
        public string Name { get; set; }
        public List<ShoppingListItemDto> Items { get; set; }
        public Guid RecipeId { get; set; }
    }
}