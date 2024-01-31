using CheckComDetail.Models;
using Microsoft.EntityFrameworkCore;

namespace CheckComDetail.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :base(options){ 
            
        }
        public DbSet<ComputerInfo> ComputerInfos { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Staff> Staffs { get; set;}
    }
}
