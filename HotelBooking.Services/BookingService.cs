namespace HotelBooking.Services
{
    using HotelBooking.Data.Interfaces;
    using HotelBooking.Services.Interfaces;
    using System.Linq;
    using HotelBooking.Models.ViewModels.AvailableDates;
    using System.Collections.Generic;
    using HotelBooking.Models.EntityModels;
    using AutoMapper;
    using System;
    using HotelBooking.Models.ViewModels.Booking;

    public class BookingService : Service, IBookingService
    {
        public BookingService(IHotelBookingDbContext context)
            : base(context)
        {

        }

        public IEnumerable<AvailableDateViewModel> GetAllAvailableDays()
        {
            IEnumerable<AvailableDate> availableDates = this.Context.AvailableDates.Where(d => d.IsAvailable == false);
            IEnumerable<AvailableDateViewModel> vms = Mapper.Map<IEnumerable<AvailableDate>, IEnumerable<AvailableDateViewModel>>(availableDates);

            return vms;
        }

        public IEnumerable<DatesPriceViewModel> GetAllDaysWithPrice()
        {
            var allDates = this.Context.AvailableDates.ToList();
            IEnumerable<DatesPriceViewModel> vms = Mapper.Map<IEnumerable<AvailableDate>, IEnumerable<DatesPriceViewModel>>(allDates);

            return vms;
        }

        public decimal GetTheAmoundForAllNights(DateTime fromDate, DateTime toDate)
        {
            DateTime includingLastDay = toDate.AddDays(1);
            var allBookedDays = this.Context.AvailableDates.Where(day => day.Date >= fromDate && day.Date <= includingLastDay).ToList();

            decimal amound = 0;
            foreach (var day in allBookedDays)
            {
                amound += day.Price;
            }

            return amound;
        }

        public bool ReserveDates(BookingConfirmationViewModel model, string reservedById)
        {
            DateTime includingLastDay = model.ToDate.AddDays(1);
            var availableDays = this.Context.AvailableDates.Where(d => d.Date >= model.FromDate && d.Date <= includingLastDay).ToList();
            foreach (var day in availableDays)
            {
                if (day.IsAvailable == true)
                {
                    day.ReservedById = reservedById;
                    day.IsAvailable = false;
                }
                else if (day.IsAvailable == false)
                {
                    return true;
                }
            }
            this.Context.SaveChanges();
            return false;
        }

        public void SaveThePaymentInfo(BookingConfirmationViewModel model, string userId)
        {
            var newPayment = new Payment()
            {
                PayerId = userId,
                Date = DateTime.Now,
                FromDate = model.FromDate,
                ToDate = model.ToDate,
                AmoundPerAllNights = model.AmoundPerAllNights,
                BookedDays = model.BookedDays,
                CleaningFee = model.CleaningFee,
                RefundableDamageDeposit = model.RefundableDamageDeposit,
                TotalPrice = model.TotalPrice
            };

            this.Context.Payments.Add(newPayment);
            this.Context.SaveChanges();
        }

        // dsdsdadadadsasdadas
        public void UnreserveDates(BookingConfirmationViewModel model)
        {
            DateTime includingLastDay = model.ToDate.AddDays(1);
            var availableDays = this.Context.AvailableDates.Where(d => d.Date >= model.FromDate && d.Date <= includingLastDay).ToList();
            foreach (var day in availableDays)
            {
                day.ReservedById = null;
                day.IsAvailable = true;    
            }

            this.Context.SaveChanges();
        }
    }
}
