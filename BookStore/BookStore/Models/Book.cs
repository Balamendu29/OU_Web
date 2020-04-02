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

        [Required(ErrorMessage = "Please enter Book title.")]
        [StringLength(20, MinimumLength = 3)]
        public string title { get; set; }

        public string author { get; set; }
        public int writtenyear { get; set; }
        public string edition { get; set; }
        public float price { get; set; }
    }
}
