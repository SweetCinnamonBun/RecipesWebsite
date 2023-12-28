using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RecipesAPI.Models.Domain
{
    public class ShoppingList
    {
        public Guid Id { get; set; }
        public Guid Name { get; set; }
        public List<ShoppingListItem> Items { get; set; }
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}