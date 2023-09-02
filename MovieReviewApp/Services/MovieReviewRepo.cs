using Microsoft.EntityFrameworkCore;
using MovieReviewApp.Context;
using MovieReviewApp.Models;

namespace MovieReviewApp.Services
{
    public class MovieReviewRepo : IMovieReview
    {
        private readonly MovieContext _context;
        public MovieReviewRepo(MovieContext context)
        {
            _context = context;
        }

        public void DeleteMovieReview(MovieReview movieReview)
        {
            _context.Remove(movieReview);
        }

        public async Task<MovieReview?> GetMovieReviewAsync(int id)
        {
            return await _context.MovieReviews.Where(m => m.MovieReviewId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<MovieReview>> GetMovieReviewsAsync()
        {
            return await _context.MovieReviews.ToListAsync();
        }

        public async Task PostMovieReview(MovieReview movieReview)
        {
            await _context.MovieReviews.AddAsync(movieReview);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public void UpdateMovieReview(MovieReview movieReview)
        {
            _context.Entry(movieReview).State = EntityState.Modified;
        }
    }
}
