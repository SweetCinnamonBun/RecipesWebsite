using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.Models.DTO.Images
{
    public class ImageDto
    {

        public IFormFile File { get; set; }

        public string FileName { get; set; }

        public string? FileDescription { get; set; }

        public string FilePath { get; set; }

        public Guid RecipeId { get; set; }
    }
}