using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YelpcampRazorPages.Models
{
    public class Campground
    {
        public int CampgroundId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Location { get; set; }
        public string Teaser { get; set; }
        public string Body { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
