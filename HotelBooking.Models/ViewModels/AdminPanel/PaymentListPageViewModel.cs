namespace HotelBooking.Models.ViewModels.AdminPanel
{
    using System.Collections.Generic;

    public class PaymentListPageViewModel
    {
        public int page { get; set; }

        public decimal pages { get; set; }

        public IEnumerable<PaymentsViewModel> Payments { get; set; }
    }
}
