using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.Models.Domain
{
    public class Recipe
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CookingTime { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Direction> Directions { get; set; }
        public List<Category> Categories { get; set; }

    }
}