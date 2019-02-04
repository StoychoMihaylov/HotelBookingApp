using System;
using System.Collections.Generic;
using HotelBooking.Models.BindingModels;
using HotelBooking.Models.ViewModels.AvailableDates;
using HotelBooking.Models.ViewModels.Booking;

namespace HotelBooking.Services.Interfaces
{
    public interface IBookingService
    {
        bool ReserveDates(BookingConfirmationViewModel model, string reservedById);
        IEnumerable<AvailableDateViewModel> GetAllAvailableDays();
        void UnreserveDates(BookingConfirmationViewModel model);
        void SaveThePaymentInfo(BookingConfirmationViewModel model, string userId);
        IEnumerable<DatesPriceViewModel> GetAllDaysWithPrice();
        decimal GetTheAmoundForAllNights(DateTime fromDate, DateTime toDate);
    }
}
