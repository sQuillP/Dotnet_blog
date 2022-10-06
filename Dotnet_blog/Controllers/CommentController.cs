using Dotnet_blog.Models;
using Dotnet_blog.Models.VM;
using Dotnet_blog.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentService commentService;

        public CommentController(CommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            var comments = await commentService.GetAllCommentsAsync();
            return Ok(comments);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var comment = await commentService.GetCommentByIdAsync(id);
            if(comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateComment(int id, [FromBody] CommentVM commentVM)
        {
            var updatedComment = await commentService.UpdateComment(id, commentVM);
            if(UpdateComment == null)
            {
                return NotFound();
            }

            return Ok(updatedComment);
        }


        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CommentVM commentVM)
        {
            var createdComment = await commentService.CreateComment(commentVM);
            return Ok(createdComment);

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var deletedComment = await commentService.DeleteComment(id);
            if(deletedComment == null)
            {
                return NotFound();
            }
            return Ok(deletedComment);
        }
    }
}
