namespace HotelBooking.Models.ViewModels.AdminPanel
{
    using HotelBooking.Models.BindingModels.AdminPanel;
    using System.Collections.Generic;

    public class AvailableDaysListPageinViewModel
    {
        public int page { get; set; }

        public decimal pages { get; set; }

        public AvailableDateBindingModel AvailableDate { get; set; }

        public IEnumerable<AvailableDaysViewModel> AvailableDaysViewModel { get; set; }
    }
}
