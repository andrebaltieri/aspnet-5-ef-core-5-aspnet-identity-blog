using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Data;
using MyBlog.Services;

namespace MyBlog.Controllers
{
    [ApiController]
    [Route("api")]
    public class LoginController : ControllerBase
    {
        [HttpPost("v1/login")]
        public async Task<IActionResult> Login(
            [FromBody] LoginViewModel model,
            [FromServices] SignInManager<IdentityUser> signInManager,
            [FromServices] UserManager<IdentityUser> userManager,
            [FromServices] ApplicationDbContext context
        )
        {
            var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, true, lockoutOnFailure: false);
            if (result.Succeeded == false)
                return BadRequest(new { message = "Usuário ou senha inválidos" });
            
            var user = await userManager.FindByEmailAsync(model.Username);
            var roles = await userManager.GetRolesAsync(user);
            var token = TokenService.GenerateToken(user, roles);

            // Retorna os dados
            return Ok(new
            {
                user = new
                {
                    id = user.Id,
                    username = user.UserName,
                    email = user.Email,
                    roles = roles
                },
                token
            });
        }

    }
    
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}