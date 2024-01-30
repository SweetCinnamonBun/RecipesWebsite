using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.Models.DTO.Ratings
{
    public class RatingDto
    {
        public Guid Id { get; set; }
        public int Value { get; set; }
        public Guid RecipeId { get; set; }
        public string UserProfileId { get; set; }
    }
}