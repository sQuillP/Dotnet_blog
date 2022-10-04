using Dotnet_blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_blog.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Explicitly describe many-many relationships & other types of adjectives for data.
        }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<User> Users { get; set; }

    }
}
