using Microsoft.AspNetCore.Mvc;
using MovieReviewApp.Models;
using MovieReviewApp.Services;

namespace MovieReviewApp.Controllers
{
    [Route("reviews")]
    public class Review : Controller
    {
        private readonly IMovieReview _repo;
        public Review(IMovieReview repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var reviews = await _repo.GetMovieReviewsAsync();
            return View(reviews);
        }
        [HttpGet]
        [Route("create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(MovieReviewDTO review)
        {
            if (review == null)
            {
                return View("Error");
            }
            MovieReview newReview = new MovieReview { MovieReviewId = 0, MovieName = review.MovieName, ReviewComments = review.ReviewComments };
            await _repo.PostMovieReview(newReview);
            bool result = await _repo.SaveChangesAsync();
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View("Error");
        }
        [HttpGet]
        [Route("edit/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var review = await _repo.GetMovieReviewAsync(id);
            if (review == null)
            {
                return View("Error");
            }
            return View(review);
        }
        [HttpPost]
        [Route("edit/{id:int}")]
        public async Task<IActionResult> Edit(int id, MovieReviewDTO newreview)
        {
            var oldreview = await _repo.GetMovieReviewAsync(id);
            if (oldreview == null)
            {
                return View("Error");
            }
            oldreview.MovieName = newreview.MovieName;
            oldreview.ReviewComments = newreview.ReviewComments;

            _repo.UpdateMovieReview(oldreview);
            bool result = await _repo.SaveChangesAsync();
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View("Error");
        }
        [HttpGet]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var review = await _repo.GetMovieReviewAsync(id);
            if (review == null)
            {
                return View("Error");
            }
            return View(review);
        }
        [HttpPost]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var review = await _repo.GetMovieReviewAsync(id);
            if (review == null)
            {
                return View("Error");
            }
            _repo.DeleteMovieReview(review);
            bool result = await _repo.SaveChangesAsync();
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View("Error");

        }
        [HttpGet]
        [Route("details/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var review = await _repo.GetMovieReviewAsync(id);
            if (review == null)
            {
                return View("Error");
            }
            return View(review);
        }

    }
}
