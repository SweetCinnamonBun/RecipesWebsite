using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipesAPI.Data;
using RecipesAPI.Models.Domain;
using RecipesAPI.Models.DTO.Users;

namespace RecipesAPI.Repositories.Users
{
    public class SQLUserRepository : IUserRepository
    {
        private readonly RecipesDbContext dbContext;

        public SQLUserRepository(RecipesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<UserProfile> CreateAsync(UserRegisterDto userRegisterDto)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(userRegisterDto.Password);

            var newUser = new UserProfile()
            {
                Username = userRegisterDto.Username,
                Email = userRegisterDto.Email,
                PasswordHash = passwordHash,
                Role = "User"
            };

            await dbContext.UserProfiles.AddAsync(newUser);
            await dbContext.SaveChangesAsync();
            return newUser;
        }

        public async Task<UserProfile?> GetByIdAsync(Guid id)
        {
            var requestUser = await dbContext.UserProfiles.FirstOrDefaultAsync(x => x.Id == id);

            if (requestUser == null)
            {
                return null;
            }

            return requestUser;

        }


    }
}