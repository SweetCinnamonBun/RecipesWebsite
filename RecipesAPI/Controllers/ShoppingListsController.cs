using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipesAPI.Models.Domain;
using RecipesAPI.Models.DTO.ShoppingLists;
using RecipesAPI.Repositories.ShoppingLists;

namespace RecipesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingListsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IShoppingListRepository shoppingListRepository;

        public ShoppingListsController(IMapper mapper, IShoppingListRepository shoppingListRepository)
        {
            this.mapper = mapper;
            this.shoppingListRepository = shoppingListRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var shoppingLists = await shoppingListRepository.GetAllAsync();

            return Ok(mapper.Map<List<ShoppingListDto>>(shoppingLists));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddShoppingListDto addShoppingListDto)
        {
            var shoppingListDomain = mapper.Map<ShoppingList>(addShoppingListDto);

            var response = await shoppingListRepository.CreateAsync(shoppingListDomain);

            return Ok("created new shopping list");
        }

        [HttpPut]
        [Route("id:Guid")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateShoppingListDto updateShoppingListDto)
        {
            var shoppingListDomain = mapper.Map<ShoppingList>(updateShoppingListDto);

            var response = await shoppingListRepository.UpdateAsync(id, shoppingListDomain);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ShoppingListDto>(response));
        }

        [HttpDelete]
        [Route("id:Guid")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var response = await shoppingListRepository.DeleteAsync(id);

            if (response == null)
            {
                return NotFound();
            }

            return Ok("Shopping list was deleted successfully.");
        }


    }
}