using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Mission06_rcroft1.Models
{
    // creating the fields in the database
    public class MovieData
    {
        [Key][Required]
        public int MovieId { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string title { get; set; }
        [Required(ErrorMessage = "Year is required")]
        public int year { get; set; }
        [Required(ErrorMessage = "Director is required")]
        public string director { get; set; }
        [Required(ErrorMessage = "Rating is required")]
        public string rating { get; set; }
        public bool edited { get; set; }
        public string lentTo { get; set; }
        [MaxLength (25)]
        public string notes { get; set; }
        public int CategoryId { get; set; }
        //[Required(ErrorMessage = "Category is required")]
        public Categories Category { get; set; }
    }
}
