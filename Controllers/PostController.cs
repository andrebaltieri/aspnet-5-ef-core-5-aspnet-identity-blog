using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlog.Data;

namespace MyBlog.Controllers
{
    [ApiController]
    [Route("api")]
    public class PostController : ControllerBase
    {
        [HttpGet("v1/posts")]
        public async Task<IActionResult> Get([FromServices] ApplicationDbContext context)
        {
            var posts = await context.Posts.Include(x => x.Author).ToListAsync();
            return Ok(posts);
        }

        [HttpGet("v1/posts/secret")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetSecret()
        {
            return Ok("This is a secret place");
        }
    }
}