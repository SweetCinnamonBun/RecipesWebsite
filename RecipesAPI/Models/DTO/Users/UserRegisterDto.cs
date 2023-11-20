using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.Models.DTO.Users
{
    public class UserRegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Can be only 20 characters long")]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

    }
}