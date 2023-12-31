using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using RecipesAPI.Models.Domain;

namespace RecipesAPI.Models.DTO.Ingredients
{
    public class IngredientDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
        public Guid RecipeId { get; set; }
    }
}