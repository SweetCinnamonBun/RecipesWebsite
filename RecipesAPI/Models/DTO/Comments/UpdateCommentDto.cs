using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.Models.DTO.Comments
{
    public class UpdateCommentDto
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Text { get; set; }
    }
}