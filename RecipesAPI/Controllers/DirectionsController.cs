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
    public class DirectionsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IIngredientsRepository ingredientsRepository;
        public DirectionsController(IMapper mapper)
        {

            this.mapper = mapper;

        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ingredientsDomain = await ingredientsRepository.GetAllAsync();

            return Ok(mapper.Map<List<IngredientDto>>(ingredientsDomain));
        }




    }
}