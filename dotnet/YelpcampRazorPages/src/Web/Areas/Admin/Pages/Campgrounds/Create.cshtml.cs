using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using YelpcampRazorPages.Web.Data;
using YelpcampRazorPages.Web.Models;

namespace Web.Areas.Admin.Pages.Campgrounds
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly YelpcampRazorPages.Web.Data.ApplicationDbContext _context;

        public CreateModel(YelpcampRazorPages.Web.Data.ApplicationDbContext context)
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

            _context.Campgrounds.Add(Campground);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
