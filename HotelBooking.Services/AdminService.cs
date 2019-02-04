namespace HotelBooking.Services
{
    using AutoMapper;
    using HotelBooking.Data;
    using HotelBooking.Models.BindingModels.Admin;
    using HotelBooking.Models.EntityModels;
    using HotelBooking.Models.ViewModels.AdminPanel;
    using HotelBooking.Services.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class AdminService : IAdminService
    {
        private HotelBookingDbContext Context;

        public AdminService(HotelBookingDbContext context)
        {
            this.Context = context;
        }

        public void ChangeTheStateOfThisDate(DetailesAvailableDaysBindingModel bindingModel)
        {
            var date = this.Context.AvailableDates.Find(bindingModel.Id);
            if (bindingModel.IsAvailable)
            {
                date.IsAvailable = bindingModel.IsAvailable;
                date.Description = bindingModel.Description;
                date.Price = bindingModel.Price;
                date.ReservedBy = null;
            }
            else
            {
                date.IsAvailable = bindingModel.IsAvailable;
                date.Price = bindingModel.Price;
                date.Description = bindingModel.Description;
            }

            this.Context.SaveChanges();
        }

        public IEnumerable<ApplicationUser> GetAllAccounts()
        {
            var users = this.Context.Users.ToList();

            return users;
        }

        public IEnumerable<AvailableDaysViewModel> GetAllDaysAvailableAndUnavailable()
        {
            var allDays = this.Context.AvailableDates.Include("ReservedBy").ToList();

            var viewModel = Mapper.Map<IEnumerable<AvailableDate>, IEnumerable<AvailableDaysViewModel>>(allDays);

            var orderedViewModel = viewModel.OrderBy(d => d.Date);

            return orderedViewModel;
        }

        public IEnumerable<PaymentsViewModel> GetAllPayments()
        {
            var allPayments = this.Context.Payments.ToList();

            IEnumerable<PaymentsViewModel> vm = Mapper.Map<IEnumerable<Payment>, IEnumerable<PaymentsViewModel>>(allPayments);

            return vm;
        }

        public DetailesAvailableDaysBindingModel GetDetailedDayAvailability(int id)
        {
            var entity = this.Context.AvailableDates.Find(id);

            var viewModel = Mapper.Map<AvailableDate, DetailesAvailableDaysBindingModel>(entity);

            return viewModel;
        }
    }
}
