using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RecipesAPI.Data;
using RecipesAPI.Models.Domain;
using RecipesAPI.Models.DTO.Users;
using RecipesAPI.Repositories.Users;

namespace RecipesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration config;
        private readonly IUserRepository userRepository;

        public LoginController(IConfiguration config, IUserRepository userRepository)
        {

            this.config = config;
            this.userRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            var user = await Authenticate(userLoginDto);

            if (user == null)
            {
                return NotFound("User not found");
            }

            var token = Generate(user);

            return Ok(token);


        }

        private async Task<UserProfile?> Authenticate(UserLoginDto userLoginDto)
        {

            var currentUser = await userRepository.GetByUsername(userLoginDto);

            if (currentUser == null)
            {
                return null;
            }

            if (!BCrypt.Net.BCrypt.Verify(userLoginDto.Password, currentUser.PasswordHash))
            {
                return null;
            }

            return currentUser;
        }

        private string Generate(UserProfile user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(config["Jwt:Issuer"], config["Jwt:Audience"], claims, expires: DateTime.Now.AddMinutes(20), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}