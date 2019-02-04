namespace HotelBooking.Services
{
    using System.Collections.Generic;
    using HotelBooking.Data.Interfaces;
    using HotelBooking.Models.EntityModels;
    using HotelBooking.Services.Interfaces;
    using System.Data.Entity;
    using HotelBooking.Models.ViewModels.Review;
    using AutoMapper;
    using System.Linq;
    using HotelBooking.Models.BindingModels;
    using System;

    public class ReviewService : Service, IReviewServices
    {
        public ReviewService(IHotelBookingDbContext context)
            : base(context)
        {
            
        }

        public void AddCommentToTheReview(CommentBindingModel comment)
        {
            comment.SubmittedOn = DateTime.Now;

            var newCommentToReview = Mapper.Map<CommentBindingModel, Comment>(comment);

            this.Context.Comments.Add(newCommentToReview);
            this.Context.SaveChanges();
        }

        public void CreateReview(ReviewBindingModel reviewBindingModel)
        {
            reviewBindingModel.SubmittedOn = DateTime.Now;

            var newReview = Mapper.Map<ReviewBindingModel, Review>(reviewBindingModel);

            this.Context.Reviews.Add(newReview);
            this.Context.SaveChanges();
        }

        public IEnumerable<ReviewViewModel> GetAllReviews()
        {
            var reviews = this.Context.Reviews.Include(c => c.Comments).ToList();
            var viewModels = Mapper.Map<IEnumerable<Review>, IEnumerable<ReviewViewModel>>(reviews);

            var orderedReviews = viewModels.OrderBy(d => d.SubmittedOn);

            return orderedReviews;
        }
    }
}
