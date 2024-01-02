using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RecipesAPI.Models.Domain;
using RecipesAPI.Models.DTO.Categories;
using RecipesAPI.Models.DTO.Directions;
using RecipesAPI.Models.DTO.Ingredients;
using RecipesAPI.Models.DTO.ShoppingLists;

namespace RecipesAPI.Models.DTO.Recipes
{
    public class PostRecipeDto
    {
        [Required]
        [MaxLength(30, ErrorMessage = "The recipe can be no longer than 30 charachters")]
        public string Name { get; set; }

        [Required]
        public string CookingTime { get; set; }

        public List<PostIngredientDto> Ingredients { get; set; }
        public List<AddRecipeDirectionDto> Directions { get; set; }
        public List<AddCategoryDto> Categories { get; set; }
        public AddRecipeShoppingListDto ShoppingList { get; set; }

        public Guid UserProfileId { get; set; }
    }
}