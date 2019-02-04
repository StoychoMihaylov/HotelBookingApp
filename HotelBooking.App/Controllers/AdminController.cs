namespace HotelBooking.App.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using HotelBooking.Models.BindingModels.Admin;
    using HotelBooking.Models.ViewModels.AdminPanel;
    using HotelBooking.Services.Interfaces;
    using HotelBooking.Models.EntityModels;
    using System.Collections.Generic;

    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private IAdminService service;

        public AdminController(IAdminService service)
        {
            this.service = service;
            
        }

        [HttpGet]
        public ActionResult AvailableDaysList(int? id)
        {
            var idPage = id;
            var allDays = this.service.GetAllDaysAvailableAndUnavailable().ToList();
            var monthNow = DateTime.Now.Month;
            var yearNow = DateTime.Now.Year;
            var pages = 0;
            var listOfpages = new Dictionary<int, List<AvailableDaysViewModel>>();

            // Calculationg the count of pages
            foreach (var day in allDays)
            {
                if (day.Date.Month != day.Date.AddDays(1).Month)
                {
                    pages += 1;
                }
            }

            var currentStep = 1;
            var dayStep = 0;
            var executed = false;

            // Adding List of view models
            for (int i = 1; i <= pages; i++)
            {
                for (int j = dayStep; j < allDays.Count() - 1; j++)
                {
                    // Set default page 
                    if (!executed)
                    {
                        if (allDays[j].Date.Month == monthNow && allDays[j].Date.Year == yearNow && idPage == null)
                        {
                            //Set default page with the current month
                            idPage = i;
                        }

                        executed = true;
                    }                   

                    if (allDays[j].Date.Month == allDays[j + 1].Date.Month)
                    {
                        if (currentStep == i)
                        {
                            listOfpages.Add(i, new List<AvailableDaysViewModel>());
                            currentStep += 1;
                        }
                        
                        listOfpages[i].Add(allDays[j]);
                    }
                    else
                    {
                        listOfpages[i].Add(allDays[j]);
                        dayStep = j + 1;
                        break;
                    }
                }      
            }

            if (idPage <= pages && idPage != 0 && idPage != null)
            {
                AvailableDaysListPageinViewModel viewModel = new AvailableDaysListPageinViewModel()
                {
                    page = (int)idPage,
                    pages = pages,
                    AvailableDaysViewModel = listOfpages[(int)idPage]
                };

                return View(viewModel);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpGet]
        public ActionResult DetailesAvailableDay(int id)
        {
            DetailesAvailableDaysBindingModel detailedViewModel = this.service.GetDetailedDayAvailability(id);
            if (detailedViewModel == null)
            {
                return HttpNotFound();
            }

            return View(detailedViewModel);
        }

        [HttpPost]
        public ActionResult DetailesAvailableDay(DetailesAvailableDaysBindingModel bindingModel)
        {
            this.service.ChangeTheStateOfThisDate(bindingModel);

            return RedirectToAction("AvailableDaysList", "Admin");
        }

        [HttpGet]
        public ActionResult AccountsList(int? id)
        {
            if (id == null)
            {
                id = 1;
            }

            IEnumerable<ApplicationUser> users = this.service.GetAllAccounts();

            decimal pages = Math.Round((decimal)users.Count() / 20);

            if (pages == 0)
            {
                pages = 1;
            }

            if (id <= pages && id != 0 && id != null)
            {
                var viewDate = users.Skip(((int)id - 1) * 20).Take(20);

                AccountListPageViewModel viewModel = new AccountListPageViewModel()
                {
                    page = (int)id,
                    pages = pages,
                    Accounts = viewDate
                };

                return View(viewModel);
            }

            return HttpNotFound();
        }

        public ActionResult PaymentsList(int? id)
        {
            if (id == null)
            {
                id = 1;
            }

            var payments = this.service.GetAllPayments();
            if (payments == null)
            {
                return HttpNotFound();
            }

            decimal pages = Math.Round((decimal)payments.Count() / 20);
            if (pages == 0)
            {
                pages = 1;
            }

            if (id <= pages && id != 0 && id != null)
            {
                PaymentListPageViewModel viewModel = new PaymentListPageViewModel()
                {
                    page = (int)id,
                    pages = pages,
                    Payments = payments
                };

                return View(viewModel);
            }

            return HttpNotFound();           
        }

    }
}
