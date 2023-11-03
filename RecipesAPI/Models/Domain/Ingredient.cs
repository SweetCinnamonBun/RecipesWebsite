using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.Models.Domain
{
    public class Ingredient
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
        public Guid RecipeId { get; set; }

        //Navigation 
        public Recipe Recipe { get; set; }
    }
}