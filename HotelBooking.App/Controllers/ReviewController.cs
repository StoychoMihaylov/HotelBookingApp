namespace HotelBooking.App.Controllers
{
    using HotelBooking.Models.ViewModels.Review;
    using HotelBooking.Services.Interfaces;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Web.Mvc;

    public class ReviewController : Controller
    {
        private IReviewServices service;

        public ReviewController(IReviewServices service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult List()
        {
            ReviewVmAndReviewBmViewModel model = new ReviewVmAndReviewBmViewModel();

            var reviewsVms = this.service.GetAllReviews();
            if (reviewsVms == null)
            {
                return this.HttpNotFound();
            }

            model.ReviewViewModel = reviewsVms;

            return View(model);
        }

        [HttpPost]
        public ActionResult List(ReviewVmAndReviewBmViewModel model)
        {
            var reviewBindingModel = model.ReviewBidnginModel;

            reviewBindingModel.AuthorId = User.Identity.GetUserId();

            this.service.CreateReview(reviewBindingModel);

            return RedirectToAction("List", "Review");
        }

        [HttpPost]
        public ActionResult AddComment(ReviewVmAndReviewBmViewModel model, int reviewId)
        {
            var comment = model.CommentBindingModel;

            comment.ReviewId = reviewId;
            comment.AuthorId = User.Identity.GetUserId();

            this.service.AddCommentToTheReview(comment);

            return RedirectToAction("List", "Review");
        }
    }
}