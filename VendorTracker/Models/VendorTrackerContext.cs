using Microsoft.EntityFrameworkCore;


namespace VendorTracker.Models
{
    public class VendorTrackerContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public VendorTrackerContext(DbContextOptions options) : base(options) { }
    }
}