using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipesAPI.Models.Domain;
using RecipesAPI.Models.DTO.Categories;
using RecipesAPI.Models.DTO.Comments;
using RecipesAPI.Models.DTO.Directions;
using RecipesAPI.Models.DTO.Ingredients;
using RecipesAPI.Models.DTO.Ratings;
using RecipesAPI.Models.DTO.ShoppingLists;

namespace RecipesAPI.Models.DTO.Recipes
{
    public class RecipeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CookingTime { get; set; }
        public List<IngredientDto> Ingredients { get; set; }
        public List<DirectionDto> Directions { get; set; }
        public List<CategoryDto> Categories { get; set; }
        public List<CommentDto> Comments { get; set; }
        public List<RatingDto> Ratings { get; set; }
        public ShoppingListDto ShoppingList { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}