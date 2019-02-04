namespace HotelBooking.Services.Interfaces
{
    using HotelBooking.Models.ViewModels.Review;
    using System.Collections.Generic;
    using HotelBooking.Models.BindingModels;

    public interface IReviewServices
    {
        IEnumerable<ReviewViewModel> GetAllReviews();
        void CreateReview(ReviewBindingModel reviewBindingModel);
        void AddCommentToTheReview(CommentBindingModel comment);
    }
}
