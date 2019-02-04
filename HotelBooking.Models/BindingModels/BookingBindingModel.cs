using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Models.BindingModels
{
    public class BookingBindingModel
    {
        [Display(Name = "From")]
        public DateTime FromDate { get; set; }

        [Display(Name = "To")]
        public DateTime ToDate { get; set; }

        public bool IsAvailable { get; set; }

        [ForeignKey("ReservedBy")]
        public string ReservedById { get; set; }
    }
}
