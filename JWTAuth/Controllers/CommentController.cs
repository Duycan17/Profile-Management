using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JWTAuth.Models;
using JWTAuth.Services;

namespace JWTAuth.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("{commentId}")]
        public async Task<ActionResult<Comment>> GetCommentById(int commentId)
        {
            var comment = await _commentService.GetCommentById(commentId);

            if (comment == null)
            {
                return NotFound(); // Return 404 if comment not found
            }

            return Ok(comment);
        }

        [HttpGet]
        public async Task<ActionResult<List<Comment>>> GetAllComments()
        {
            var comments = await _commentService.GetAllComments();
            return Ok(comments);
        }

        [HttpPost]
        public async Task<ActionResult<Comment>> CreateComment([FromBody] CommentDTO newComment)
        {
            var createdComment = await _commentService.CreateCommentAsync(newComment);
            return CreatedAtAction(nameof(GetCommentById), new { commentId = createdComment.CommentId }, createdComment);
        }

        [HttpPut("{commentId}")]
        public async Task<ActionResult<Comment>> UpdateComment(int commentId, [FromBody] CommentDTO updatedComment)
        {
            var updated = await _commentService.UpdateCommentAsync(commentId, updatedComment);

            if (updated == null)
            {
                return NotFound(); // Return 404 if comment not found
            }

            return Ok(updated);
        }

        [HttpDelete("{commentId}")]
        public async Task<ActionResult> DeleteComment(int commentId)
        {
            var result = await _commentService.DeleteCommentAsync(commentId);

            if (!result)
            {
                return NotFound(); // Return 404 if comment not found
            }

            return NoContent();
        }
        [HttpGet("byProfile/{profileId}")]
        public async Task<ActionResult<List<Comment>>> GetCommentsByProfileId(int profileId)
        {
            var comments = await _commentService.GetCommentsByProfileId(profileId);

            if (comments == null || comments.Count == 0)
            {
                return NotFound(); // Return 404 if no comments found for the profileId
            }

            return Ok(comments);
        }
    }
}
