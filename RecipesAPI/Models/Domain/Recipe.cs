using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.Models.Domain
{
    public class Recipe
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Cannot be that long")]
        public string Name { get; set; }
        public int CookingTime { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Direction> Directions { get; set; }
        public List<Category> Categories { get; set; }

    }
}