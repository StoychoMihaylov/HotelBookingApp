namespace HotelBooking.Models.ViewModels.AdminPanel
{
    using HotelBooking.Models.EntityModels;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;

    public class AvailableDaysViewModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public bool IsAvailable { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        [ForeignKey("ReservedBy")]
        public string ReservedById { get; set; }

        public virtual ApplicationUser ReservedBy { get; set; }

        public static implicit operator List<object>(AvailableDaysViewModel v)
        {
            throw new NotImplementedException();
        }
    }
}
