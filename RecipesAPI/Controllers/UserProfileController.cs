using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipesAPI.Data;
using RecipesAPI.Models.Domain;
using RecipesAPI.Models.DTO.Users;

namespace RecipesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserProfileController : ControllerBase
    {
        private readonly RecipesDbContext dbContext;
        private readonly UserManager<UserProfile> userManager;

        public UserProfileController(RecipesDbContext dbContext, UserManager<UserProfile> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
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
    }
}