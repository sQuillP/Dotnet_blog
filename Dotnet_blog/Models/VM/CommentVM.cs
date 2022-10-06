namespace Dotnet_blog.Models.VM
{
    public class CommentVM
    {

        public int Id { get; set; }

        public string? Content { get; set; }

        public int? Likes { get; set; } = 0;


        public int? Dislikes { get; set; } = 0;


        public int BlogId { get; set; }


        public int UserId { get; set; }


    }
}
