using MovieReviewApp.Models;

namespace MovieReviewApp.Services
{
    public interface IMovieReview
    {
        Task<IEnumerable<MovieReview>> GetMovieReviewsAsync();
        Task<MovieReview?> GetMovieReviewAsync(int id);
        Task PostMovieReview(MovieReview movieReview);
        void UpdateMovieReview(MovieReview movieReview);
        void DeleteMovieReview(MovieReview movieReview);
        Task<bool> SaveChangesAsync();
    }
}
