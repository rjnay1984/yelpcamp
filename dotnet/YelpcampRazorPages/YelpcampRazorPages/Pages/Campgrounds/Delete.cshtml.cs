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
    public class DeleteModel : PageModel
    {
        private readonly YelpcampRazorPages.Data.ApplicationDbContext _context;

        public DeleteModel(YelpcampRazorPages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Campground Campground { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Campground = await _context.Campground.FirstOrDefaultAsync(m => m.CampgroundId == id);

            if (Campground == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Campground = await _context.Campground.FindAsync(id);

            if (Campground != null)
            {
                _context.Campground.Remove(Campground);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
