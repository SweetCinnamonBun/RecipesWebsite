using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipesAPI.Models.Domain;
using RecipesAPI.Models.DTO.Ingredients;

namespace RecipesAPI.Models.DTO.Recipes
{
    public class UpdateRecipeDto
    {
        public string Name { get; set; }
        public int CookingTime { get; set; }
        // public List<IngredientDto> Ingredients { get; set; }
        // public List<Direction> Directions { get; set; }
        // public List<Category> Categories { get; set; }
    }
}