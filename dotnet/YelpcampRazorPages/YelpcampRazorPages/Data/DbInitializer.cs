using YelpcampRazorPages.Data;
using YelpcampRazorPages.Models;
using System;
using System.Linq;

namespace YelpcampRazorPages.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any campgrounds.
            if (context.Campground.Any())
            {
                return;   // DB has been seeded
            }

            var campgrounds = new Campground[]
            {
                new Campground{Title="Campground One",Location="Des Moines, IA",Teaser="Campground One teaser.",Body="Campground One Body."},
                new Campground{Title="Campground Two",Location="Area 51",Teaser="Campground Two teaser.",Body="Campground Two body."}
            };

            context.Campground.AddRange(campgrounds);
            context.SaveChanges();

            var comments = new Comment[]
            {
                new Comment{Body="Comment one.",CampgroundId=1},
                new Comment{Body="Comment two.",CampgroundId=1},
                new Comment{Body="Comment three.",CampgroundId=2},
                new Comment{Body="Comment four.",CampgroundId=2}
            };

            context.Comment.AddRange(comments);
            context.SaveChanges();
        }
    }
}
