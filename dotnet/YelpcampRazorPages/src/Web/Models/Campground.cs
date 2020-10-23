using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YelpcampRazorPages.Web.Models
{
    public class Campground
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Location { get; set; }

        public string Teaser { get; set; }

        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
    }
}
