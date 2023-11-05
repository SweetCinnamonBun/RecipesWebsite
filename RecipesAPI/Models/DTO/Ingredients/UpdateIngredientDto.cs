using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.Models.DTO.Ingredients
{
    public class UpdateIngredientDto
    {
        public string Name { get; set; }
        public string Amount { get; set; }
    }
}