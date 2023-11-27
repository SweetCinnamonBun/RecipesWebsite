using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipesAPI.Models.Domain;

namespace RecipesAPI.Repositories.Ingredients
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}