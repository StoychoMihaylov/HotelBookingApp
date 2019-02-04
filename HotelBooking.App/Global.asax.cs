namespace HotelBooking.App
{
    using System.Web;
    using AutoMapper;
    using System.Web.Mvc;
    using System.Web.Routing;
    using System.Web.Optimization;
    using HotelBooking.Models.BindingModels;
    using HotelBooking.Models.BindingModels.Admin;
    using HotelBooking.Models.EntityModels;
    using HotelBooking.Models.ViewModels.AdminPanel;
    using HotelBooking.Models.ViewModels.AvailableDates;
    using HotelBooking.Models.ViewModels.Review;
    

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureMapper();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Review, ReviewViewModel>();
                expression.CreateMap<ReviewBindingModel, Review>();
                expression.CreateMap<AvailableDate, AvailableDateViewModel>();
                expression.CreateMap<CommentBindingModel, Comment>();
                expression.CreateMap<AvailableDate, AvailableDaysViewModel>()
                    .ForMember(d => d.ReservedBy, configExpression => 
                        configExpression.MapFrom( date => date.ReservedBy));
                expression.CreateMap<AvailableDate, DetailesAvailableDaysBindingModel>();
                expression.CreateMap<Payment, PaymentsViewModel>();
            });
        }
    }
}
