using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipesAPI.Models.Domain;

namespace RecipesAPI.Models.DTO.ShoppingLists
{
    public class ShoppingListItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
        public bool IsMarked { get; set; }
        // public Guid ShoppingListId { get; set; }

        //Navigation 
        // public ShoppingListDto ShoppingList { get; set; }
    }
}