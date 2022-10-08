namespace Dotnet_blog.Models
{
    public class Comment
    {

        public int Id { get; set; }


        public string Content { get; set; }


        public int Likes { get; set; } = 0;


        public int Dislikes { get; set; } = 0;


        public DateTime PostedOn { get; set; }


        public int BlogId { get; set; }


        public Blog Blog { get; set; }


        public int UserId { get; set; }


        public User User { get; set; }
    }


    public class CommentAttachment
    {
        public int Id { get; set; }


        public string Content { get; set; }


        public int Likes { get; set; } = 0;


        public int Dislikes { get; set; } = 0;

        public DateTime PostedOn { get; set; }


        public int BlogId { get; set; }

        public int UserId { get; set; }

    }
}
