using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipesAPI.Data;
using RecipesAPI.Models.Domain;
using RecipesAPI.Models.DTO.Recipes;
using RecipesAPI.Repositories.Recipes;

namespace RecipesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly RecipesDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IRecipeRepository recipeRepository;

        public RecipesController(RecipesDbContext dbContext, IMapper mapper, IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
            this.mapper = mapper;
            this.dbContext = dbContext;
        }


        // GET: https://localhost:portnumber/api/Recipes
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var recipesDomain = await recipeRepository.GetAllAsync();


            var recipesDto = mapper.Map<List<RecipeDto>>(recipesDomain);

            return Ok(recipesDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var recipeDomain = await recipeRepository.GetByIdAsync(id);

            if (recipeDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<RecipeDto>(recipeDomain));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] PostRecipeDto postRecipeDto)
        {
            var recipe = mapper.Map<Recipe>(postRecipeDto);

            // var user = await dbContext.UserProfiles.FirstOrDefaultAsync(x => x.Id == postRecipeDto.UserProfileId);
            // recipe.UserProfile = user;
            recipe.CreatedAt = DateTime.Now;

            var categoryNames = recipe.Categories.Select(x => x.Name).ToList();
            var categories = dbContext.Categories
            .Where(x => categoryNames.Contains(x.Name))
            .ToList();

            // var category = await dbContext.Categories.FirstOrDefaultAsync(x => x.Name.ToLower() == categoryName);

            if (categories == null)
            {
                // Handle the case where the category doesn't exist
                return NotFound("Category not found");
            }

            recipe.Categories.Clear();

            // Add the category to the recipe
            recipe.Categories.AddRange(categories);

            // Add the recipe to the context
            await dbContext.Recipes.AddAsync(recipe);

            // Save changes
            await dbContext.SaveChangesAsync();

            return Ok("Success");
        }

        [HttpPut]
        [Route("{id:Guid}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRecipeDto updateRecipeDto)
        {
            var recipeDomain = mapper.Map<Recipe>(updateRecipeDto);

            recipeDomain = await recipeRepository.UpdateAsync(id, recipeDomain);

            if (recipeDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<RecipeDto>(recipeDomain));


        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedRecipe = await recipeRepository.DeleteAsync(id);

            if (deletedRecipe == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<RecipeDto>(deletedRecipe));
        }
    }
}