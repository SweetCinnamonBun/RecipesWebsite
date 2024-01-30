using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.Models.DTO.Comments
{
    public class AddCommentDto
    {
        public string Username { get; set; }

        public string Text { get; set; }

        public Guid RecipeId { get; set; }

        public string UserProfileId { get; set; }
    }
}