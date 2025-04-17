using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieWise.Service.MovieService;
using MovieWise.ViewModels.Movie;


namespace MovieWise.Controllers
{
    public class MoviesController : Controller
    {
        IMovieService _movieService;
        IMapper _mapper;

        public MoviesController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        // Read (Index)
        public async Task<IActionResult> Index()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return View(_mapper.Map<IEnumerable<ShowMovieVM>>(movies));
        }
    }
}
