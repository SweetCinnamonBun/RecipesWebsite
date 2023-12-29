using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.Models.Domain
{
    public class Rating
    {
        public Guid Id { get; set; }
        public int Value { get; set; }
        public Guid RecipeId { get; set; }
        public Guid UserProfileId { get; set; }

        //Navigation
        public Recipe Recipe { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}