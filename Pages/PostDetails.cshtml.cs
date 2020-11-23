using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBlog.Data;
using MyBlog.Models;

namespace MyBlog.Pages
{
    public class PostDetails : PageModel
    {
        public Post Post { get; set; }

        public async Task<IActionResult> OnGet(string url, [FromServices] ApplicationDbContext context)
        {
            Post = await context.Posts.Include(x => x.Author).FirstOrDefaultAsync(x => x.Url == url);
            if (Post == null)
                return NotFound();

            return Page();
        }
    }
}