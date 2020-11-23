using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyBlog.Data;

namespace MyBlog.Pages
{
    public class IndexModel : PageModel
    {
        public IList<Models.Post> Posts { get; set; }
        
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGet([FromServices] ApplicationDbContext context)
        {
            Posts = await context.Posts.ToListAsync();
        }
    }
}