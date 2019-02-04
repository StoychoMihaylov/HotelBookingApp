namespace HotelBooking.Services.Interfaces
{
    using System.Collections.Generic;
    using HotelBooking.Models.BindingModels.Admin;
    using HotelBooking.Models.EntityModels;
    using HotelBooking.Models.ViewModels.AdminPanel;

    public interface IAdminService
    {
        IEnumerable<AvailableDaysViewModel> GetAllDaysAvailableAndUnavailable();

        DetailesAvailableDaysBindingModel GetDetailedDayAvailability(int id);

        void ChangeTheStateOfThisDate(DetailesAvailableDaysBindingModel bindingModel);

        IEnumerable<ApplicationUser> GetAllAccounts();

        IEnumerable<PaymentsViewModel> GetAllPayments();
    }
}
