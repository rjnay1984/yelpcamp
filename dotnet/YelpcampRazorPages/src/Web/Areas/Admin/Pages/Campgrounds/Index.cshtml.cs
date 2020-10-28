using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YelpcampRazorPages.Web.Data;
using YelpcampRazorPages.Web.Models;

namespace Web.Areas.Admin.Pages.Campgrounds
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly YelpcampRazorPages.Web.Data.ApplicationDbContext _context;

        public IndexModel(YelpcampRazorPages.Web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Campground> Campground { get;set; }

        public async Task OnGetAsync()
        {
            Campground = await _context.Campgrounds.ToListAsync();
        }
    }
}
