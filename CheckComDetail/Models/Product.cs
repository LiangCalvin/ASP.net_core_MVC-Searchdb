using System.ComponentModel.DataAnnotations;

namespace CheckComDetail.Models
{
    public class Product
    {
        // Primary key for the customer
        [Key]
        public int ProductID { get; set; }

        // Customer details
        public string ProductBrand { get; set; }
        public string ProductModel { get; set; }
        public int ProductPrice { get; set; }

    }
}
