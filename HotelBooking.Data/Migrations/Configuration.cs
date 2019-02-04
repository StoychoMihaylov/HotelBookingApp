namespace HotelBooking.Data.Migrations
{
    using HotelBooking.Models.EntityModels;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<HotelBookingDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(HotelBookingDbContext context)
        {
            //Set up user roles
            if (!context.Roles.Any())
            {
                this.CreateRole(context, "Admin");
                this.CreateRole(context, "ClienUser");
            }

            if (!context.Users.Any())
            {
                this.CreateUser(context, "admin@admin.com", "Admin", "123");
                this.SetRoleToUser(context, "admin@admin.com", "Admin");
            }

            if (!context.Roles.Any(role => role.Name == "ClienUser"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manage = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("ClienUser");
                manage.Create(role);
            }

            //Adding all available days
            var currentDays = context.AvailableDates.ToList();
            var newDays = AddAvailableDaysFiveYearsInAdvans(currentDays);

            foreach (var day in newDays)
            {
                context.AvailableDates.Add(day);
            }

            context.SaveChanges();
        }

        private List<AvailableDate> AddAvailableDaysFiveYearsInAdvans(List<AvailableDate> currentDays)
        {
            var newDays = new List<AvailableDate>();

            var isContains = false;
            for (int i = 0; i <= 365 * 5; i++)
            {
                AvailableDate newDay = new AvailableDate
                {
                    Date = DateTime.Now.AddDays(i),
                    Price = 399,
                    IsAvailable = true,
                };

                foreach (var current in currentDays)
                {
                    if (current.Date.Day == newDay.Date.Day && current.Date.Month == newDay.Date.Month && current.Date.Year == newDay.Date.Year)
                    {
                        isContains = true;
                    }
                }

                if (!isContains)
                {
                    newDays.Add(newDay);
                }
                else
                {
                    isContains = false;
                }
            }

            return newDays;
        }

        private void SetRoleToUser(HotelBookingDbContext context, string email, string role)
        {
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            var user = context.Users.Where(u => u.Email == email).First();

            var result = userManager.AddToRole(user.Id, role);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(";", result.Errors));
            }
        }

        private void CreateUser(HotelBookingDbContext context, string email, string fullName, string password)
        {
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 3,
                RequireDigit = false,
                RequireLowercase = false,
                RequireNonLetterOrDigit = false,
                RequireUppercase = false,
            };

            var admin = new ApplicationUser
            {
                UserName = email,
                Email = email,
            };

            var result = userManager.Create(admin, password);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(";", result.Errors));
            }
        }

        private void CreateRole(HotelBookingDbContext context, string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));

            var result = roleManager.Create(new IdentityRole(roleName));

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(";", result.Errors));
            }
        }
    }
}
