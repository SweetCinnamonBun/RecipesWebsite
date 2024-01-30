using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RecipesAPI.Controllers;

namespace RecipesAPI.Models.Domain
{
    public class UserProfile : IdentityUser
    {
        // public Guid Id { get; set; }
        // public string Username { get; set; }
        // public string Email { get; set; }
        // public string PasswordHash { get; set; }
        // public string Role { get; set; }
        public List<Recipe> Recipes { get; set; }

        public string? Address { get; set; }
        // public List<Comment> Comments { get; set; }
        // public List<Rating> Ratings { get; set; }
    }
}