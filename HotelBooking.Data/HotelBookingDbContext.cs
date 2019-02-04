namespace HotelBooking.Data
{
    using System.Data.Entity;
    using HotelBooking.Data.Interfaces;
    using HotelBooking.Models.EntityModels;
    using Microsoft.AspNet.Identity.EntityFramework;
    using HotelBooking.Data.Migrations;

    public class HotelBookingDbContext : IdentityDbContext<ApplicationUser>, IHotelBookingDbContext
    {
        public HotelBookingDbContext()
            : base("name=HotelBookingDbContext", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<HotelBookingDbContext, Configuration>());
        }

        public DbSet<Review> Reviews { get; set ; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<AvailableDate> AvailableDates { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public static HotelBookingDbContext Create()
        {
            return new HotelBookingDbContext();
        }
    }
}