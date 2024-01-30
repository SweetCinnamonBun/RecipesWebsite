using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipesAPI.Data;
using RecipesAPI.Models.Domain;

namespace RecipesAPI.Repositories.Comments
{
    public class SQLCommentsRepository : ICommentsRepository
    {
        private readonly RecipesDbContext dbContext;

        public SQLCommentsRepository(RecipesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Comment> CreateAsync(Comment comment)
        {
            await dbContext.Comments.AddAsync(comment);
            await dbContext.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment?> DeleteAsync(Guid id)
        {
            var response = await dbContext.Comments.FirstOrDefaultAsync(x => x.Id == id);

            if (response == null)
            {
                return null;
            }

            dbContext.Remove(response);
            await dbContext.SaveChangesAsync();

            return response;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            var comments = await dbContext.Comments.ToListAsync();

            return comments;
        }

        public async Task<Comment?> GetByIdAsync(Guid id)
        {
            var comment = await dbContext.Comments.FirstOrDefaultAsync(x => x.Id == id);

            if (comment == null)
            {
                return null;
            }

            return comment;
        }

        public async Task<List<Comment>> GetUserComments(string id)
        {


            var userComments = await dbContext.Comments.Where(x => x.UserProfileId == id).ToListAsync();
            return userComments;
        }

        public async Task<Comment?> UpdateAsync(Guid id, Comment comment)
        {
            var commentUpdate = await dbContext.Comments.FirstOrDefaultAsync(x => x.Id == id);

            if (commentUpdate == null)
            {
                return null;
            }

            commentUpdate.Text = comment.Text;
            await dbContext.SaveChangesAsync();
            return commentUpdate;

        }
    }
}