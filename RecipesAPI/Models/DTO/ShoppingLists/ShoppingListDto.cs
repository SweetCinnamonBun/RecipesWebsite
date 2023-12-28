using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipesAPI.Models.DTO.Recipes;

namespace RecipesAPI.Models.DTO.ShoppingLists
{
    public class ShoppingListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<ShoppingListItemDto> Items { get; set; }
        public Guid RecipeId { get; set; }
        public RecipeDto Recipe { get; set; }
    }
}