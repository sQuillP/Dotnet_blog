using Dotnet_blog.Data;
using Dotnet_blog.Models;
using Dotnet_blog.Models.VM;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_blog.Services
{
    public class CommentService
    {
        private readonly ApplicationDbContext context;

        public CommentService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Comment>> GetAllCommentsAsync()
        {
            return await context.Comments.ToListAsync();
        }

        public async Task<Comment> GetCommentByIdAsync(int id)
        {
            var fetchedComment = await context.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if (fetchedComment == null)
                return null;
            return fetchedComment;
        }

        public async Task<Comment> UpdateComment(int id, CommentVM commentVM)
        {
           var fetchedComment = await  context.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if(fetchedComment == null)
            {
                return null;
            }
            if (commentVM.Likes != null && commentVM.Likes != fetchedComment.Likes)
                fetchedComment.Likes = (int) commentVM.Likes;
            if (commentVM.Dislikes != null && commentVM.Likes != fetchedComment.Likes)
                fetchedComment.Dislikes = (int)commentVM.Dislikes;
            if (commentVM.Content != null && commentVM.Content != fetchedComment.Content)
                fetchedComment.Content = commentVM.Content;
            await context.SaveChangesAsync();
            return fetchedComment;
        }

        public async Task<Comment> DeleteComment(int id)
        {
            Comment comment = await context.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if(comment == null)
            {
                return null;
            }

            context.Comments.Remove(comment);

            await context.SaveChangesAsync();

            return comment;
        }


        public async Task<Comment> CreateComment(CommentVM commentVM)
        {
            Comment comment = new Comment()
            {
                Content = commentVM.Content,
                Likes = 0,
                Dislikes = 0,
                BlogId = commentVM.BlogId,
                UserId = commentVM.UserId,
                PostedOn = DateTime.Now
            };
            await context.Comments.AddAsync(comment);
            await context.SaveChangesAsync();
            return comment;
        }
    }
}
