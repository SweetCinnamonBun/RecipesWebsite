using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipesAPI.Models.Domain;
using RecipesAPI.Models.DTO.Directions;
using RecipesAPI.Models.DTO.Ingredients;
using RecipesAPI.Repositories.Directions;
using RecipesAPI.Repositories.Ingredients;

namespace RecipesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DirectionsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IDirectionsRepository directionsRepository;

        public DirectionsController(IMapper mapper, IDirectionsRepository directionsRepository)
        {

            this.mapper = mapper;
            this.directionsRepository = directionsRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var directions = await directionsRepository.GetAllAsync();

            return Ok(mapper.Map<List<DirectionDto>>(directions));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddDirectionDto addDirectionDto)
        {
            var directionDomain = mapper.Map<Direction>(addDirectionDto);

            var response = await directionsRepository.CreateAsync(directionDomain);

            return Ok(response);

        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateDirectionDto updateDirectionDto)
        {
            var directionDomain = mapper.Map<Direction>(updateDirectionDto);

            var response = await directionsRepository.UpdateAsync(id, directionDomain);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<DirectionDto>(response));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var directionDomain = await directionsRepository.DeleteAsync(id);

            if (directionDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<DirectionDto>(directionDomain));
        }




    }
}