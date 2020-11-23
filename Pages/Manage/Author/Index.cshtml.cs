using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MyBlog.Pages.Manage.Author
{
    public class IndexModel : PageModel
    {
        private readonly MyBlog.Data.ApplicationDbContext _context;

        public IndexModel(MyBlog.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.Author> Author { get;set; }

        public async Task OnGetAsync()
        {
            Author = await _context.Authors.ToListAsync();
        }
    }
}
