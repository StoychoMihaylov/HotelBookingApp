namespace HotelBooking.App.Controllers
{
    using HotelBooking.Models.BindingModels;
    using HotelBooking.Models.ViewModels.AvailableDates;
    using HotelBooking.Models.ViewModels.Booking;
    using HotelBooking.Services.Interfaces;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class BookController : Controller
    {

        private IBookingService service;

        public BookController(IBookingService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult Booking()
        {
            IEnumerable<DatesPriceViewModel> allDaysWithPrice = this.service.GetAllDaysWithPrice();
            IEnumerable<AvailableDateViewModel> availableDaysVm = this.service.GetAllAvailableDays();

            ViewBag.DaysWithPrice = allDaysWithPrice;
            ViewBag.Dates = availableDaysVm;

            return View();
        }

        [HttpPost]
        public ActionResult Booking(BookingBindingModel model)
        {
            // Reservatior
            model.ReservedById = User.Identity.GetUserId();

            if (model.ToDate < model.FromDate)
            {
                TempData["errorMessage"] = $"The last day of your stay cannot be before the first day. Please enter correct dates!";
                return RedirectToAction("Booking", "Book");
            }

            int bookedDays = model.ToDate.AddDays(1).Subtract(model.FromDate).Days;
            if (bookedDays < 2)
            {
                TempData["errorMessage"] = $"Minimum stay at the Oasis Pool Resort is 2 Nights.";
                return RedirectToAction("Booking", "Book");
            }

            if (model.FromDate <= DateTime.Now && model.FromDate.Year != 1)
            {
                TempData["errorMessage"] = $"Sorry, dates before today {DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year} cannot be ordered!";
                return RedirectToAction("Booking", "Book");
            }

            if (model.FromDate.Year == 1 || model.ToDate.Year == 1)
            {
                TempData["errorMessage"] = $"Please select and enter dates of your desired stay.";
                return RedirectToAction("Booking", "Book");
            }

            var fromDate = model.FromDate;
            var toDate = model.ToDate;

            return RedirectToAction("BookingConfirmation", "Book", new { fromDate, toDate });
        }

        [HttpGet]
        [Authorize]
        public ActionResult BookingConfirmation(DateTime fromDate, DateTime toDate)
        {
            decimal amoundForAllNights = this.service.GetTheAmoundForAllNights(fromDate, toDate);
            int bookedDays = toDate.AddDays(1).Subtract(fromDate).Days;
            decimal cleaningFee = 200.00M;
            decimal refundableDamageDeposit = 500.00M;
            decimal totalPrice = amoundForAllNights + cleaningFee + refundableDamageDeposit;

            BookingConfirmationViewModel confirmModel = new BookingConfirmationViewModel();
            confirmModel.FromDate = fromDate;
            confirmModel.ToDate = toDate;
            confirmModel.BookedDays = bookedDays;
            confirmModel.AmoundPerAllNights = amoundForAllNights;
            confirmModel.CleaningFee = cleaningFee;
            confirmModel.RefundableDamageDeposit = refundableDamageDeposit;
            confirmModel.TotalPrice = totalPrice;

            TempData["confirmModel"] = confirmModel;

            return View(confirmModel);
        }

        [HttpPost]
        public ActionResult BookingConfirmation()
        {
            var model = TempData["confirmModel"] as BookingConfirmationViewModel;

            // User ID
            var userId = User.Identity.GetUserId();

            // Reserving of Date
            var isDateAlreadyReserved = this.service.ReserveDates(model, userId);
            if (isDateAlreadyReserved == true)
            {
                TempData["errorMessage"] = "This dates are already reserved, please check for available dates.";
                return RedirectToAction("Booking", "Book");
            }
            else
            {
                //SaveThePaymentData
                this.service.SaveThePaymentInfo(model, userId);

                TempData["successMessage"] = "Congrats! You have booked your stay!";
                return RedirectToAction("BookingSuccessful", "Book");
            }

            //this.service.UnreserveDates(model);
        }

        [HttpGet]
        public ActionResult DownloadRentalAgreement()
        {
            var fileName = "RentalAgreement.pdf";
            var filepath = $"~/Content/RentalAgreement/{fileName}";
            byte[] fileBytes = System.IO.File.ReadAllBytes(Server.MapPath(filepath));
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        [HttpGet]
        public ActionResult BookingSuccessful()
        {
            return View();
        }
    }
}