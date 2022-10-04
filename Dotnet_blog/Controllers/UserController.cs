using Dotnet_blog.Models;
using Dotnet_blog.Models.VM;
using Dotnet_blog.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_blog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userService.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUser([FromRoute]int id)
        {
            var user = await userService.GetUserAsync(id);

            if (user == null)
                return NotFound();
            return Ok(user);

        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody]UserVM user)
        {
            var createdUser = await userService.CreateUserAsync(user);
            return Ok(createdUser);
        }


        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute]int id, [FromBody]UserVM update)
        {
            var updatedUser = await userService.UpdateUserAsync(id, update);
            if(updatedUser == null)
            {
                return NotFound();
            }
            return Ok(updatedUser);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute]int id)
        {
            var deletedUser = await userService.DeleteUserAsync(id);
            if (deletedUser == null)
                return NotFound();
            return Ok(deletedUser);
        }
    }
}
