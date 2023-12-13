using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JWTAuth.Models;

namespace JWTAuth.Services
{
    public class CommentService : ICommentService
    {
        private readonly DataContext _dbContext; // Replace YourDbContext with your actual DbContext class

        public CommentService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Comment> GetCommentById(int commentId)
        {
            return await _dbContext.Comments.FindAsync(commentId);
        }

        public async Task<List<Comment>> GetAllComments()
        {
            return await _dbContext.Comments.ToListAsync();
        }
        public async Task<Comment> CreateCommentAsync(CommentDTO newComment)
        {
            var commentEntity = new Comment
            {
                ProfileId = newComment.ProfileId,
                UserId = newComment.UserId,
                CommentText = newComment.CommentText,
                Timestamp = newComment.Timestamp
            };

            _dbContext.Comments.Add(commentEntity);
            await SaveChangesAsync();

            return commentEntity;
        }
        public async Task<Comment> UpdateCommentAsync(int commentId, CommentDTO updatedComment)
        {
            var existingComment = await _dbContext.Comments.FindAsync(commentId);

            if (existingComment == null)
                return null; // Comment not found
            existingComment.CommentText = updatedComment.CommentText;

            await SaveChangesAsync();

            return existingComment;
        }


        public async Task<bool> DeleteCommentAsync(int commentId)
        {
            var commentToDelete = await _dbContext.Comments.FindAsync(commentId);

            if (commentToDelete == null)
                return false; // Comment not found

            _dbContext.Comments.Remove(commentToDelete);
            await SaveChangesAsync();
            return true;
        }

        public async System.Threading.Tasks.Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<Comment>> GetCommentsByProfileId(int profileId)
        {
            // Implement the logic to retrieve comments by profileId from the database
            // For example:
            var comments = await _dbContext.Comments.Where(c => c.ProfileId == profileId).ToListAsync();

            return comments;
        }
    }
}
