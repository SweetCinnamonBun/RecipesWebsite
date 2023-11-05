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

namespace RecipesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly RecipesDbContext dbContext;
        private readonly IMapper mapper;

        public RecipesController(RecipesDbContext dbContext, IMapper mapper)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }


        // GET: https://localhost:portnumber/api/Recipes
        [HttpGet]
        public IActionResult GetAll()
        {
            var recipes = dbContext.Recipes.Include(r => r.Ingredients).ToList();


            var recipesDto = mapper.Map<List<RecipeDto>>(recipes);

            return Ok(recipesDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var recipe = dbContext.Recipes.Include(i => i.Ingredients).FirstOrDefault(x => x.Id == id);

            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<RecipeDto>(recipe));
        }

        [HttpPost]
        public IActionResult Post([FromBody] PostRecipeDto postRecipeDto)
        {
            var recipeDomain = mapper.Map<Recipe>(postRecipeDto);

            dbContext.Recipes.Add(recipeDomain);
            dbContext.SaveChanges();

            var recipeDto = mapper.Map<RecipeDto>(recipeDomain);

            return CreatedAtAction(nameof(GetById), new { id = recipeDto.Id }, recipeDto);
        }
    }
}