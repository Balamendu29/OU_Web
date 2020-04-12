using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace BookStore.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Book title is required.")]
        //[Required(ErrorMessageResourceName = "TitleRequired", ErrorMessageResourceType = typeof(Book))]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Title")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter Book Author...")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        [StringLength(30)]
        [Display(Name = "Author")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Please enter Book written year...For ex:2020")]
        //[StringLength(4)]
        [RegularExpression("^[12][0-9]{3}$", ErrorMessage = "Year must be numeric with 4-digits from 1000 to 2999. For ex:2020")]
        //[DisplayFormat(DataFormatString = "{0:yyyy}")]
        //[DataType(DataType.Date)]
        [Display(Name = "Year Written")]
        public int Writtenyear { get; set; }

        [Required(ErrorMessage = "Please enter Book Edition...")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        [Display(Name = "Edition")]
        public string Edition { get; set; }

        [Display(Name = "Price")]
        //[RegularExpression("^[0-9]*$.", ErrorMessage = "Only Numbers allowed.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        //[DisplayFormat(DataFormatString = Book.test())]
        public decimal Price { get; set; }

        private DateTime _date = DateTime.Now;
        [DataType(DataType.Date)]
        [Display(Name ="Created Date")]
        public DateTime CreatedDate { get { return _date; } set { _date = value; } }
        //public DateTime CreatedDate { get; set; }

        [Display(Name = "Image File")]
        public string imagepath { get; set; }

        [NotMapped]
        [Display(Name = "Upload ImageFile")]
        public IFormFile imagefile { get; set; }

    }
}
