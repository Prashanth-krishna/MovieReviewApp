using System.ComponentModel.DataAnnotations.Schema;

namespace MovieReviewApp.Models
{
    public class MovieReview
    {
        public int MovieReviewId { get; set; }
        public string MovieName { get; set; } = null!;
        [Column(TypeName = "varchar(MAX)")]
        public string ReviewComments { get; set; } = null!;
    }
}
