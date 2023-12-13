using System.Collections.Generic;
using System.Threading.Tasks;
using JWTAuth.Models;

namespace JWTAuth.Services
{
    public interface ICommentService
    {
        Task<Comment> GetCommentById(int commentId);
        Task<List<Comment>> GetAllComments();
        Task<Comment> CreateCommentAsync(CommentDTO newComment);
        Task<Comment> UpdateCommentAsync(int commentId, CommentDTO updatedComment);
        Task<bool> DeleteCommentAsync(int commentId);
        System.Threading.Tasks.Task SaveChangesAsync();
        Task<List<Comment>> GetCommentsByProfileId(int profileId);

    }
}
