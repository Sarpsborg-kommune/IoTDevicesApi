using Microsoft.EntityFrameworkCore;

namespace IoTDevicesApi.Models
{
    public class IoTDevicesContext : DbContext
    {
        public DbSet<IoTDevice> IoTDevices { get; set; }

        public IoTDevicesContext(DbContextOptions<IoTDevicesContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultContainer("SkIoTDevices");
            modelBuilder.Entity<IoTDevice>().ToContainer("SkIoTDevices");
            modelBuilder.Entity<IoTDevice>().HasNoDiscriminator();
            modelBuilder.Entity<IoTDevice>().OwnsOne(o => o.location);
        }
    }
}