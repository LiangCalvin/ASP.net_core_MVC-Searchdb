using System.ComponentModel.DataAnnotations;

namespace CheckComDetail.Models
{
    public class Customer
    {
        // Primary key for the customer
        [Key]
        public int CustomerId { get; set; }

        // Customer details
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string Device { get; set; }
        public string? Agent { get; set; }

    }
}
