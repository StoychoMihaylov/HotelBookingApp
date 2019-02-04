using HotelBooking.Models.EntityModels;
using System.Data.Entity;

namespace HotelBooking.Data.Interfaces
{
    public interface IHotelBookingDbContext
    {
        DbSet<Review> Reviews { get; set; }

        DbSet<Comment> Comments { get; set; }

        DbSet<AvailableDate> AvailableDates { get; set; }

        DbSet<Payment> Payments { get; set; } 

        int SaveChanges();
    }
}
