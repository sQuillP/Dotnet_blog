namespace Dotnet_blog.Models
{
    public class Blog
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        public int Views { get; set; }


        public int UserId { get; set; }

        public User User { get; set; }

        //navigation properties

        public IEnumerable<Comment> Comments { get; set; }


    }
}
