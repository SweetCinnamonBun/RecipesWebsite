using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.Models.DTO.Ratings
{
    public class AddRatingDto
    {
        public int Value { get; set; }
        public Guid RecipeId { get; set; }
        public Guid UserProfileId { get; set; }
    }
}