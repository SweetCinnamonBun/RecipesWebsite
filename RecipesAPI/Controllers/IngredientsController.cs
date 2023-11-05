using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipesAPI.Models.Domain;
using RecipesAPI.Models.DTO.Ingredients;
using RecipesAPI.Repositories.Ingredients;

namespace RecipesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IIngredientsRepository ingredientsRepository;
        public IngredientsController(IMapper mapper, IIngredientsRepository ingredientsRepository)
        {
            this.ingredientsRepository = ingredientsRepository;
            this.mapper = mapper;

        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ingredientsDomain = await ingredientsRepository.GetAllAsync();

            return Ok(mapper.Map<List<IngredientDto>>(ingredientsDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var ingredientDomain = await ingredientsRepository.GetByIdAsync(id);

            if (ingredientDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<IngredientDto>(ingredientDomain));
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostIngredientDto postIngredientDto)
        {
            var ingredientDomain = mapper.Map<Ingredient>(postIngredientDto);

            ingredientDomain = await ingredientsRepository.CreateAsync(ingredientDomain);

            var ingredientDto = mapper.Map<IngredientDto>(ingredientDomain);

            return Ok(ingredientDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateIngredientDto updateIngredientDto)
        {

            var ingredientDomain = new Ingredient
            {
                Name = updateIngredientDto.Name,
                Amount = updateIngredientDto.Amount
            };

            ingredientDomain = await ingredientsRepository.UpdateAsync(id, ingredientDomain);

            if (ingredientDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<IngredientDto>(ingredientDomain));


        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedIngredient = await ingredientsRepository.DeleteAsync(id);

            if (deletedIngredient == null)
            {
                return NotFound();
            }

            return Ok("Deletion was successfull");
        }
    }
}