using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipesAPI.Models.Domain;
using RecipesAPI.Models.DTO.Users;

namespace RecipesAPI.Repositories.Users
{
    public interface IUserRepository
    {
        Task<UserProfile?> GetByIdAsync(Guid id);
        Task<UserProfile?> CreateAsync(UserRegisterDto userRegisterDto);

        Task<UserProfile?> GetByUsername(UserLoginDto userLoginDto);
    }
}