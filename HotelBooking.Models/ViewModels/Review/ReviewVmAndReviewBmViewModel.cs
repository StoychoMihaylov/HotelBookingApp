namespace HotelBooking.Models.ViewModels.Review
{
    using HotelBooking.Models.BindingModels;
    using System.Collections.Generic;

    public class ReviewVmAndReviewBmViewModel
    {
        public ReviewBindingModel ReviewBidnginModel { get; set; }

        public CommentBindingModel CommentBindingModel { get; set; }

        public IEnumerable<ReviewViewModel> ReviewViewModel { get; set; }
    }
}
