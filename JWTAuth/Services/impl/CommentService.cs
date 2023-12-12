using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; // Include this if you're using Entity Framework Core
using JWTAuth.Models;
using Task = System.Threading.Tasks.Task;

namespace JWTAuth.Services
{
    public class CommentService : ICommentService
    {
        private readonly DataContext _dbContext;

        public CommentService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Comment> GetCommentById(int commentId)
        {
            return await _dbContext.Comments
                .FirstOrDefaultAsync(c => c.CommentId == commentId);
        }

        public async Task<List<Comment>> GetAllComments()
        {
            return await _dbContext.Comments.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
