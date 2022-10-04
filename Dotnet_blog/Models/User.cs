using Microsoft.EntityFrameworkCore;

namespace Dotnet_blog.Models
{
    [Index(propertyNames: nameof(Email), IsUnique =true)]
    public class User
    {
        public int Id { get; set; }

        public string FullName { get; set; }


        public string Email { get; set; }


        public string Password { get; set; }

        //Navigation properties

    }
}
