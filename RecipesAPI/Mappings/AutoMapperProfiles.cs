using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RecipesAPI.Models.Domain;
using RecipesAPI.Models.DTO.Ingredients;
using RecipesAPI.Models.DTO.Recipes;
using RecipesAPI.Models.DTO.Users;
using RecipesAPI.Models.DTO.Directions;
using RecipesAPI.Models.DTO.ShoppingLists;
using RecipesAPI.Models.DTO.Comments;
using RecipesAPI.Models.DTO.Ratings;
using RecipesAPI.Models.DTO.Categories;


namespace RecipesAPI.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // ForMember(x => x.Name, opt => opt.MapFrom(x => x.FullName))

            //Recipe
            CreateMap<Recipe, RecipeDto>().ReverseMap();
            CreateMap<Recipe, PostRecipeDto>().ReverseMap();
            CreateMap<Recipe, UpdateRecipeDto>().ReverseMap();



            //Ingredient
            CreateMap<Ingredient, IngredientDto>().ReverseMap();
            CreateMap<Ingredient, PostIngredientDto>().ReverseMap();
            CreateMap<Ingredient, UpdateIngredientDto>().ReverseMap();

            //Direction
            CreateMap<Direction, DirectionDto>().ReverseMap();
            CreateMap<Direction, AddDirectionDto>().ReverseMap();
            CreateMap<Direction, UpdateDirectionDto>().ReverseMap();

            //Comment
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Comment, AddCommentDto>().ReverseMap();
            CreateMap<Comment, UpdateCommentDto>().ReverseMap();

            //Rating
            CreateMap<Rating, RatingDto>().ReverseMap();
            CreateMap<Rating, AddRatingDto>().ReverseMap();
            CreateMap<Rating, UpdateRatingDto>().ReverseMap();

            //Category
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, AddCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            //Shopping List

            CreateMap<ShoppingList, ShoppingListDto>().ReverseMap();
            CreateMap<ShoppingList, UpdateShoppingListDto>().ReverseMap();
            CreateMap<ShoppingList, AddShoppingListDto>().ReverseMap();
            CreateMap<ShoppingListItem, ShoppingListItemDto>().ReverseMap();

            CreateMap<UserProfile, UserProfileDto>().ReverseMap();






        }
    }
}