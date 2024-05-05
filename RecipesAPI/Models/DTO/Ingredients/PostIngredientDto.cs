using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.Models.DTO.Ingredients
{
    public class PostIngredientDto
    {

        public string Name { get; set; }
        public string Amount { get; set; }
        // public Guid RecipeId { get; set; }
    }
}