using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.Models.Domain
{
    public class Category
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid RecipeId { get; set; }

        //Navigation 
        public Recipe Recipe { get; set; }
    }
}