namespace HotelBooking.Models.BindingModels.Admin
{
    using System;
    using HotelBooking.Models.EntityModels;   
    using System.ComponentModel.DataAnnotations.Schema;

    public class DetailesAvailableDaysBindingModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public bool IsAvailable { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        [ForeignKey("ReservedBy")]
        public string ReservedById { get; set; }

        public virtual ApplicationUser ReservedBy { get; set; }
    }
}
