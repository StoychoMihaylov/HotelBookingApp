using HotelBooking.Data.Interfaces;

namespace HotelBooking.Services
{
    public class Service
    {
        public Service(IHotelBookingDbContext context)
        {
            this.Context = context;
        }

        protected IHotelBookingDbContext Context { get; }
    }
}
