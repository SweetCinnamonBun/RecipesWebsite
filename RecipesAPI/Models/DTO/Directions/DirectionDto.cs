using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipesAPI.Models.Domain;
using RecipesAPI.Models.DTO.Ingredients;

namespace RecipesAPI.Models.DTO.Directions
{
    public class DirectionDto
    {
        public Guid Id { get; set; }
        public int StepNumber { get; set; }
        public string Description { get; set; }
        public Guid RecipeId { get; set; }

        //Navigation 
        public Recipe Recipe { get; set; }

    }
}