using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YelpcampRazorPages.Web.Data;
using YelpcampRazorPages.Web.Models;

namespace Web.Areas.Admin.Pages.Campgrounds
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly YelpcampRazorPages.Web.Data.ApplicationDbContext _context;

        public EditModel(YelpcampRazorPages.Web.Data.ApplicationDbContext context)
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

            Campground = await _context.Campgrounds.FirstOrDefaultAsync(m => m.ID == id);

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
                if (!CampgroundExists(Campground.ID))
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
            return _context.Campgrounds.Any(e => e.ID == id);
        }
    }
}
