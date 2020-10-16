using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YelpcampRazorPages.Data;
using YelpcampRazorPages.Models;

namespace YelpcampRazorPages.Pages.Campgrounds
{
    public class IndexModel : PageModel
    {
        private readonly YelpcampRazorPages.Data.ApplicationDbContext _context;

        public IndexModel(YelpcampRazorPages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Campground> Campground { get;set; }

        public async Task OnGetAsync()
        {
            Campground = await _context.Campground.ToListAsync();
        }
    }
}
