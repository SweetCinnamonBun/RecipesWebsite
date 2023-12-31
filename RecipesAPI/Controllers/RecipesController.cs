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
            // Assuming recipe.Categories is not null and has at least one category
            var categoryName = recipe.Categories[0].Name.ToLower();

            var category = await dbContext.Categories.SingleOrDefaultAsync(x => x.Name.ToLower() == categoryName);

            if (category == null)
            {
                // Handle the case where the category doesn't exist
                return NotFound("Category not found");
            }

            // Attach or add the category to the context based on its state
            if (dbContext.Entry(category).State == EntityState.Detached)
            {
                dbContext.Categories.Attach(category);
            }

            // Set the state of the category to Unchanged
            dbContext.Entry(category).State = EntityState.Unchanged;


            recipe.Categories.Clear();

            // Add the category to the recipe
            recipe.Categories.Add(category);

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