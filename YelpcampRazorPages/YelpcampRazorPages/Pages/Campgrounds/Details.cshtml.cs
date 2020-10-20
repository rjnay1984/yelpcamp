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
    public class DetailsModel : PageModel
    {
        private readonly YelpcampRazorPages.Data.ApplicationDbContext _context;

        public DetailsModel(YelpcampRazorPages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Campground Campground { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Campground = await _context.Campground
                .Include(m => m.Comments)
                .FirstOrDefaultAsync(m => m.CampgroundId == id);

            if (Campground == null)
            {
                return NotFound();
            }
            return Page();
        }

        [BindProperty]
        
        public Comment Comment { get; set; }

        public async Task<IActionResult> OnPostAsync(Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Comment.Add(comment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
