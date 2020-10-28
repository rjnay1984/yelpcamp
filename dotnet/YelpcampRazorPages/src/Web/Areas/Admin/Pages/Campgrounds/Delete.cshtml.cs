﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly YelpcampRazorPages.Web.Data.ApplicationDbContext _context;

        public DeleteModel(YelpcampRazorPages.Web.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Campground = await _context.Campgrounds.FindAsync(id);

            if (Campground != null)
            {
                _context.Campgrounds.Remove(Campground);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
