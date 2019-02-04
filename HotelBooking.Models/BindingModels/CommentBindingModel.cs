namespace HotelBooking.Models.BindingModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using System.ComponentModel.DataAnnotations.Schema;
    public class CommentBindingModel
    {
        [Required]
        public string Content { get; set; }

        public DateTime SubmittedOn { get; set; }

        [ForeignKey("Author")]
        public string AuthorId { get; set; }

        [ForeignKey("Review")]
        public int ReviewId { get; set; }
    }
}
