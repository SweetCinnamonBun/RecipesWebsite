using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipesAPI.Data;
using RecipesAPI.Models.Domain;
using RecipesAPI.Models.DTO;
using RecipesAPI.Models.DTO.Users;
using RecipesAPI.Repositories;

namespace RecipesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserProfileController : ControllerBase
    {
        private readonly RecipesDbContext dbContext;
        private readonly UserManager<UserProfile> userManager;
        private readonly ITokenRepository tokenRepository;

        public UserProfileController(RecipesDbContext dbContext, UserManager<UserProfile> userManager, ITokenRepository tokenRepository)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        [HttpGet]
        [Route("{id}")]

        public async Task<IActionResult> GetUserById([FromRoute] string id)
        {
            var user = await dbContext.UserProfiles.Include(x => x.Recipes).FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] AddUserDto addUserDto)
        {

            var identityUser = new UserProfile
            {
                Email = addUserDto.Username,
                UserName = addUserDto.Username
            };

            var identityResult = await userManager.CreateAsync(identityUser, addUserDto.Password);

            if (identityResult.Succeeded)
            {
                // Add roles
                if (addUserDto.Roles != null && addUserDto.Roles.Any())
                {

                    identityResult = await userManager.AddToRolesAsync(identityUser, addUserDto.Roles);

                    if (identityResult.Succeeded)
                    {
                        return Ok("User was registered");
                    }
                }
            }

            return BadRequest("Failed to register user: " + string.Join(", ", identityResult.Errors.Select(e => e.Description)));
        }

        [HttpPost]
        [Route("auth/login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            var user = await userManager.FindByEmailAsync(userLoginDto.Username);

            if (user != null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, userLoginDto.Password);

                if (checkPasswordResult)
                {
                    var roles = await userManager.GetRolesAsync(user);

                    if (roles != null)
                    {
                        var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());

                        var response = new LoginResponseDto
                        {
                            JwtToken = jwtToken
                        };

                        return Ok(response);
                    }

                }
            }

            return BadRequest("Didn't work");
        }
    }
}