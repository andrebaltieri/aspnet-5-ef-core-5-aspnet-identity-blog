using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBlog.Data;
using MyBlog.Models;

namespace MyBlog.Pages.Manage.Post
{
    public class IndexModel : PageModel
    {
        private readonly MyBlog.Data.ApplicationDbContext _context;

        public IndexModel(MyBlog.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.Post> Post { get;set; }

        public async Task OnGetAsync()
        {
            Post = await _context.Posts.ToListAsync();
        }
    }
}
