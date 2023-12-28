using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.Models.DTO.Directions
{
    public class UpdateDirectionDto
    {
        public int StepNumber { get; set; }
        public string Description { get; set; }
    }
}