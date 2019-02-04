namespace HotelBooking.Models.ViewModels.AdminPanel
{
    using HotelBooking.Models.EntityModels;
    using System.Collections.Generic;

    public class AccountListPageViewModel
    {
        public int page { get; set; }

        public decimal pages { get; set; }

        public IEnumerable<ApplicationUser> Accounts { get; set; }
    }
}
