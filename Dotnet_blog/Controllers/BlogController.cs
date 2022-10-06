using Dotnet_blog.Models.VM;
using Dotnet_blog.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BlogService blogService;

        public BlogController(BlogService blogService)
        {
            this.blogService = blogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogs()
        {
            var blogsList = await blogService.GetAllBlogsAsync();
            return Ok(blogsList);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBlogAsync(int id)
        {
            var fetchedBlog = await blogService.GetBlogByIdAsync(id);
            return Ok(fetchedBlog);
        }


        [HttpPost]
        public async Task<IActionResult> CreateBlog([FromBody]BlogVM blogVM)
        {
            var createdBlog = await blogService.CreateBlogAsync(blogVM);
            return Ok(createdBlog);
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateBlogAsync([FromRoute] int id, [FromBody] BlogVM blogVM)
        {
            var updatedBlog = await blogService.UpdateBlogAsync(id, blogVM);
            if(updatedBlog == null)
            {
                return NotFound();
            }
            return Ok(updatedBlog);
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBlogAsync([FromRoute] int id)
        {
            var deletedBlog = await blogService.DeleteBlogAsync(id);
            if(deletedBlog == null)
            {
                return NotFound();
            }
            return Ok(deletedBlog);
        }
    }
}
