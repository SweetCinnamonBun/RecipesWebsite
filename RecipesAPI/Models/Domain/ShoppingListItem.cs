using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.Models.Domain
{
    public class ShoppingListItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
        public bool IsMarked { get; set; }
        public Guid ShoppingListId { get; set; }

        //Navigation 
        public ShoppingList ShoppingList { get; set; }
    }
}