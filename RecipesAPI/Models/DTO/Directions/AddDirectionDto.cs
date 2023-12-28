using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.Models.DTO.Directions
{
    public class AddDirectionDto
    {
        public int StepNumber { get; set; }
        public string Description { get; set; }
        public Guid RecipeId { get; set; }
    }
}