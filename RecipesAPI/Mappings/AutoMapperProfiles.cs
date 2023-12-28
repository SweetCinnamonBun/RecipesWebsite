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


namespace RecipesAPI.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // ForMember(x => x.Name, opt => opt.MapFrom(x => x.FullName))
            CreateMap<RecipeDto, Recipe>().ReverseMap();
            CreateMap<PostRecipeDto, Recipe>().ReverseMap();
            CreateMap<Ingredient, IngredientDto>().ReverseMap();
            CreateMap<PostIngredientDto, Ingredient>().ReverseMap();
            CreateMap<UpdateRecipeDto, Recipe>().ReverseMap();
            CreateMap<UpdateIngredientDto, Ingredient>().ReverseMap();
            CreateMap<UserProfile, UserProfileDto>().ReverseMap();
            CreateMap<DirectionDto, Direction>().ReverseMap();
            CreateMap<AddDirectionDto, Direction>().ReverseMap();
            CreateMap<UpdateDirectionDto, Direction>().ReverseMap();
            CreateMap<ShoppingListDto, ShoppingList>().ReverseMap();
            CreateMap<AddShoppingListDto, ShoppingList>().ReverseMap();
            CreateMap<UpdateShoppingListDto, ShoppingList>().ReverseMap();
            CreateMap<ShoppingListItemDto, ShoppingListItem>().ReverseMap();


        }
    }
}