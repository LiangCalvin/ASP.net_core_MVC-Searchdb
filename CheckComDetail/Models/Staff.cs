using System.ComponentModel.DataAnnotations;

namespace CheckComDetail.Models
{
    public class Staff
    {
        // Primary key for the customer
        [Key]
        public int StaffId { get; set; }

        // Customer details
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? City { get; set; }
    }
}
