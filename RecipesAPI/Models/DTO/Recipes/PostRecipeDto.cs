using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RecipesAPI.Models.Domain;
using RecipesAPI.Models.DTO.Categories;
using RecipesAPI.Models.DTO.Ingredients;

namespace RecipesAPI.Models.DTO.Recipes
{
    public class PostRecipeDto
    {
        [Required]
        [MaxLength(30, ErrorMessage = "Max length of the recipe is 30 characters")]
        public string Name { get; set; }

        [Required]
        public int CookingTime { get; set; }
        public List<PostIngredientDto> Ingredients { get; set; }
        // public List<Direction> Directions { get; set; }
        public List<AddCategoryDto> Categories { get; set; }
    }
}