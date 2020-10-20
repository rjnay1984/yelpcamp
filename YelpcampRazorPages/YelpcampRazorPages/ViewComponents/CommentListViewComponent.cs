using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YelpcampRazorPages.Models;

namespace YelpcampRazorPages.Pages.Campgrounds.Comments
{
    public class CommentListViewComponent : ViewComponent
    {
        private readonly YelpcampRazorPages.Data.ApplicationDbContext _context;

        public CommentListViewComponent(YelpcampRazorPages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(
            int campgroundId)
        {
            var comments = await GetCommentsAsync(campgroundId);
            return View(comments);
        }

        private Task<List<Comment>> GetCommentsAsync(int campgroundId)
        {
            return _context.Comment
                .Where(c => c.CampgroundId == campgroundId)
                .ToListAsync();
        }
    }
}
