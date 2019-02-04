namespace HotelBooking.Models.ViewModels.AdminPanel
{
    using System;
    using HotelBooking.Models.EntityModels;
    using System.ComponentModel.DataAnnotations;

    public class PaymentsViewModel
    {
        public virtual ApplicationUser Payer { get; set; }

        public DateTime Date { get; set; }

        [Display(Name = "From Date: ")]
        public DateTime FromDate { get; set; }

        [Display(Name = "To Date: ")]
        public DateTime ToDate { get; set; }

        [Display(Name = "Amound Per Night: ")]
        public decimal AmoundPerNight { get; set; }

        [Display(Name = "Booked Nights: ")]
        public int BookedDays { get; set; }

        [Display(Name = "Price For All Nights: ")]
        public decimal AmoundPerAllNights { get; set; }

        [Display(Name = "Cleaning Fee: ")]
        public decimal CleaningFee { get; set; }

        [Display(Name = "Refundable Damge Deposit: ")]
        public decimal RefundableDamageDeposit { get; set; }

        [Display(Name = "Total Price: ")]
        public decimal TotalPrice { get; set; }
    }
}
