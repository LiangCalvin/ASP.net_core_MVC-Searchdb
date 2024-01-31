namespace CheckComDetail.Models
{
    public class SearchViewModel
    {
        // Define properties based on your requirements
        public List<ComputerInfo> ComputerInfoResults { get; set; }
        public List<Customer> CustomerResults { get; set; }
        public List<Product> ProductResults { get; set; }
        public List<Staff> StaffResults { get; set; }
        public string SearchTerm { get; set; }
    }
}
