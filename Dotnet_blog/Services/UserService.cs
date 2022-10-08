using Dotnet_blog.Data;
using Dotnet_blog.Models;
using Dotnet_blog.Models.VM;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_blog.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext context;

        public UserService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await context.Users.FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<User> UpdateUserAsync(int id, UserVM update)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if(user == null)
            {
                return null;
            }

            if (update.FullName != user.FullName)
                user.FullName = update.FullName;
            if (update.Email != user.Email)
                user.Email = update.Email;

            await context.SaveChangesAsync();
            return user;
        }


        public async Task<User> CreateUserAsync(UserVM userVM)
        {
            var user = new User()
            {
                Email = userVM.Email,
                Password = userVM.Password,
                FullName = userVM.FullName
            };

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user;

        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var fetchedUser = await context.Users.FirstOrDefaultAsync(x => x.Email == email);
            if(fetchedUser == null)
            {
                return null;
            }
            return fetchedUser;
        }

        public async Task<User> DeleteUserAsync(int id)
        {
            var fetchedUser = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if(fetchedUser == null)
            {
                return null;
            }
            context.Users.Remove(fetchedUser);
            await context.SaveChangesAsync();
            return fetchedUser;
        }


        
        
    }
}
