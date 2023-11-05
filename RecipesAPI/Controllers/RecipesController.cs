using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        public async Task<IActionResult> Create([FromBody] PostRecipeDto postRecipeDto)
        {
            var recipeDomain = mapper.Map<Recipe>(postRecipeDto);

            recipeDomain = await recipeRepository.CreateAsync(recipeDomain);

            var recipeDto = mapper.Map<RecipeDto>(recipeDomain);

            return CreatedAtAction(nameof(GetById), new { id = recipeDto.Id }, recipeDto);
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
    }
}