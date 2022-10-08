using Dotnet_blog.Models.VM;
using Dotnet_blog.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TokenHandler = Dotnet_blog.Services.TokenHandler;

namespace Dotnet_blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserService userService;
        private readonly Services.TokenHandler tokenHandler;

        public AuthController(UserService userService, TokenHandler tokenHandler)
        {
            this.userService = userService;
            this.tokenHandler = tokenHandler;
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser(UserVM userVM)
        {
            var fetchedUser = await userService.GetUserByEmailAsync(userVM.Email);
            if(fetchedUser == null || userVM.Password != fetchedUser.Password)
            {
                return BadRequest();
            }

            string token = await tokenHandler.CreateTokenAsync(fetchedUser);
            return Ok(token);
        }
    }
}
