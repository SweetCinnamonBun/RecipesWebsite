using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.Models.DTO.Categories
{
    public class CategoryDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}