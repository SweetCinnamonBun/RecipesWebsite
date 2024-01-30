using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipesAPI.Models.Domain;
using RecipesAPI.Models.DTO.Ratings;
using RecipesAPI.Repositories.Ratings;

namespace RecipesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IRatingsRepository ratingsRepository;

        public RatingsController(IMapper mapper, IRatingsRepository ratingsRepository)
        {
            this.mapper = mapper;
            this.ratingsRepository = ratingsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ratings = await ratingsRepository.GetAllAsync();

            return Ok(mapper.Map<List<RatingDto>>(ratings));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var rating = await ratingsRepository.GetByIdAsync(id);

            if (rating == null)
            {
                return NotFound("The Id provided is incorrect.");
            }

            return Ok(mapper.Map<RatingDto>(rating));

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddRatingDto addRatingDto)
        {
            var ratingDomain = mapper.Map<Rating>(addRatingDto);

            var response = await ratingsRepository.CreateAsync(ratingDomain);

            return Ok(response);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRatingDto updateRatingDto)
        {
            var ratingDomain = mapper.Map<Rating>(updateRatingDto);

            var updatedRating = await ratingsRepository.UpdateAsync(id, ratingDomain);

            if (updatedRating == null)
            {
                return NotFound("Ratings was not found. Please check the Id that was passed in");
            }

            return Ok("Rating was updated");
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var rating = await ratingsRepository.DeleteAsync(id);

            if (rating == null)
            {
                return NotFound();
            }

            return Ok("Rating was deleted!");
        }

        [HttpGet]
        [Route("GetUserRatings/{id}")]
        public async Task<IActionResult> GetUserRatings([FromRoute] string id)
        {
            var ratings = await ratingsRepository.GetUserRatings(id);
            return Ok(mapper.Map<List<RatingDto>>(ratings));
        }
    }
}