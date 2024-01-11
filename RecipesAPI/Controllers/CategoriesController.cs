using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipesAPI.Models.Domain;
using RecipesAPI.Models.DTO.Categories;
using RecipesAPI.Repositories.Categories;

namespace RecipesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICategoriesRepository categoriesRepository;

        public CategoriesController(IMapper mapper, ICategoriesRepository categoriesRepository)
        {
            this.mapper = mapper;
            this.categoriesRepository = categoriesRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await categoriesRepository.GetAllAsync();
            return Ok(mapper.Map<List<CategoryDto>>(categories));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddCategoryDto addCategoryDto)
        {
            var categoryDomain = mapper.Map<Category>(addCategoryDto);
            Console.WriteLine("hello");

            var response = await categoriesRepository.CreateAsync(categoryDomain);

            return Ok(mapper.Map<CategoryDto>(response));
        }


    }
}