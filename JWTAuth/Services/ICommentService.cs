using JWTAuth.Models;
using Task = System.Threading.Tasks.Task;

namespace JWTAuth.Services
{
    public interface ICommentService
    {
        Task<Comment> GetCommentById(int commentId);
        Task<List<Comment>> GetAllComments();
        Task SaveChangesAsync();
    }
}