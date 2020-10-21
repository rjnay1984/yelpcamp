using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YelpcampRazorPages.Data;
using YelpcampRazorPages.Models;

namespace YelpcampRazorPages.Pages.Campgrounds
{
    public class EditModel : PageModel
    {
        private readonly YelpcampRazorPages.Data.ApplicationDbContext _context;

        public EditModel(YelpcampRazorPages.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Campground).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampgroundExists(Campground.CampgroundId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CampgroundExists(int id)
        {
            return _context.Campground.Any(e => e.CampgroundId == id);
        }
    }
}
