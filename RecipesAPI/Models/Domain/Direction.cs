using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.Models.Domain
{
    public class Direction
    {
        public Guid Id { get; set; }
        public int StepNumber { get; set; }
        public string Description { get; set; }
        public Guid RecipeId { get; set; }

        //Navigation 
        public Recipe Recipe { get; set; }
    }
}