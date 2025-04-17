using Microsoft.AspNetCore.Mvc;
using MovieWise.Data.Repositories.Interfaces;

namespace MovieWise.Controllers
{
    public class MoviesController : Controller
    {
        IMovieRepository _movieRepository;
        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        // Read (Index)
        public async Task<IActionResult> Index()
        {
            var movies = await _movieRepository.GetAllMoviesAsync();
            return View(movies);
        }
    }
}
