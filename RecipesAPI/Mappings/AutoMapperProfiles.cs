using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RecipesAPI.Models.Domain;
using RecipesAPI.Models.DTO.Ingredients;
using RecipesAPI.Models.DTO.Recipes;

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
        }
    }
}