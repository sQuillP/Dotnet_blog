using Dotnet_blog.Data;
using Dotnet_blog.Models;
using Dotnet_blog.Models.VM;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_blog.Services
{
    public class BlogService
    {
        private readonly ApplicationDbContext context;

        public BlogService(ApplicationDbContext context)
        {
            this.context = context;
        }


        public async Task<IEnumerable<Blog>> GetAllBlogsAsync()
        {
            return await context.Blogs.ToListAsync();
        }


        public async Task<Blog> GetBlogByIdAsync(int id)
        {
            var blog = await context.Blogs.Include(blog => blog.Comments).FirstOrDefaultAsync(x => x.Id == id);
            return blog;
        }

        public async Task<Blog> UpdateBlogAsync(int id, BlogVM blogVM)
        {
            var fetchedBlog = await context.Blogs.FirstOrDefaultAsync(x => x.Id == id);
            if(fetchedBlog == null)
            {
                return null;
            }
            if(blogVM.Content != null)
            {
                fetchedBlog.Content = blogVM.Content;
            }
            if(blogVM.Title != null)
            {
                fetchedBlog.Title = blogVM.Title;
            }

            await context.SaveChangesAsync();
            return fetchedBlog;
        }

        public async Task<Blog> CreateBlogAsync(BlogVM blogVM)
        {
            var createdBlog = new Blog()
            {
                Title = blogVM.Title,
                Content = blogVM.Content != null ? blogVM.Content : "",
                UserId = blogVM.UserId,
                CreatedDate = DateTime.Now,
                Views = 0,
            };

            await context.Blogs.AddAsync(createdBlog);
            await context.SaveChangesAsync();
            return createdBlog;
        }


        public async Task<Blog> DeleteBlogAsync(int id)
        {
            var fetchedBlog = await context.Blogs.FirstOrDefaultAsync(x => x.Id == id);

            if(fetchedBlog == null)
            {
                return null;
            }

            context.Blogs.Remove(fetchedBlog);
            await context.SaveChangesAsync();
            return fetchedBlog;
        }


        
    }
}
