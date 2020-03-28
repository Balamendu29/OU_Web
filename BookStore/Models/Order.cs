using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressType { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public int BookID { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public decimal BookCost { get; set; }
        public decimal SalesTax { get; set; }


    }
}
