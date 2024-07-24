using Microsoft.EntityFrameworkCore;
using lockerSystem.Models;

namespace lockerSystem.Models
{
    public class LockerSystemContext : DbContext
    {
        public DbSet<tblRole> tblRole { get; set; }
        public DbSet<tblPermission> tblPermission { get; set; }
        public DbSet<tblBooking> tblBooking { get; set; }
        public DbSet<tblBookingState> tblBookingState { get; set; }
        public DbSet<tblBuilding> tblBuilding { get; set; }
        public DbSet<tblFloor> tblFloor { get; set; }
        public DbSet<tblLocker> tblLocker { get; set; }
        public DbSet<tblLockerState> tblLockerState { get; set; }
        public DbSet<tblManagement> tblManagement { get; set; }
        public DbSet<tblSemster> tblSemster { get; set; }
        public DbSet<tblUser> tblUser { get; set; }
       



        public LockerSystemContext()
        {

        }

        public LockerSystemContext(DbContextOptions<LockerSystemContext> options)
                   : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile("appsettings.json")
           .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DBCS"));
        }
        public DbSet<lockerSystem.Models.BookingLog>? BookingLog { get; set; }
    }
}
