using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MyBlog.Pages.Manage.Author
{
    public class DetailsModel : PageModel
    {
        private readonly MyBlog.Data.ApplicationDbContext _context;

        public DetailsModel(MyBlog.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Models.Author Author { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Author = await _context.Authors.FirstOrDefaultAsync(m => m.Id == id);

            if (Author == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
