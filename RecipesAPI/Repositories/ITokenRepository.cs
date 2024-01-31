using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RecipesAPI.Models.Domain;

namespace RecipesAPI.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(UserProfile user, List<string> roles);
    }
}