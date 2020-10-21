using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YelpcampRazorPages.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        [Required]
        public string Body { get; set; }
        public int CampgroundId { get; set; }
        public Campground Campground { get; set; }
    }
}
