using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using YelpcampRazorPages.Data;
using YelpcampRazorPages.Models;

namespace YelpcampRazorPages.Pages.Campgrounds
{
    public class CreateModel : PageModel
    {
        private readonly YelpcampRazorPages.Data.ApplicationDbContext _context;

        public CreateModel(YelpcampRazorPages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Campground Campground { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Campground.Add(Campground);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
