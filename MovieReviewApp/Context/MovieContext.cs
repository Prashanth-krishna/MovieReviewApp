using Microsoft.EntityFrameworkCore;
using MovieReviewApp.Models;

namespace MovieReviewApp.Context
{
    public class MovieContext:DbContext
    {
        public DbSet<MovieReview> MovieReviews { get; set; }
        public MovieContext(DbContextOptions opt):base(opt) 
        {

        }

    }
}
