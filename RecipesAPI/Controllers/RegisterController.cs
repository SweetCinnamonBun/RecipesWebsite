using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipesAPI.Models.DTO.Users;
using RecipesAPI.Repositories.Users;

namespace RecipesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        // private readonly IConfiguration config;
        // private readonly IUserRepository userRepository;

        // private readonly IMapper mapper;
        // public RegisterController(IConfiguration config, IUserRepository userRepository, IMapper mapper)
        // {
        //     this.mapper = mapper;
        //     this.userRepository = userRepository;
        //     this.config = config;

        // }

        // [AllowAnonymous]
        // [HttpPost]
        // public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegisterDto)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         var newUser = await userRepository.CreateAsync(userRegisterDto);
        //         return Ok(mapper.Map<UserProfileDto>(newUser));
        //     }

        //     return BadRequest("Something went wrong");
        // }
    }
}