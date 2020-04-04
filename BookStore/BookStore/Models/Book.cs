using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Book title...")]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter Book Author...")]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Author")]
        public string Author { get; set; }

        [Display(Name = "Year Written")]
        public int Writtenyear { get; set; }
        [Display(Name = "Edition")]
        public string Edition { get; set; }
        [Display(Name = "Price")]
        public float Price { get; set; }
    }
}
