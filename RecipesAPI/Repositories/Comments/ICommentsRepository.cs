using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipesAPI.Models.Domain;

namespace RecipesAPI.Repositories.Comments
{
    public interface ICommentsRepository
    {
        Task<Comment> CreateAsync(Comment comment);
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(Guid id);

        Task<Comment?> UpdateAsync(Guid id, Comment comment);

        Task<Comment?> DeleteAsync(Guid id);

        Task<List<Comment>> GetUserComments(string id);
    }
}