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
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return View(_mapper.Map<IEnumerable<ShowMovieVM>>(movies));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateMovieVM movie)
        {
            try
            {
                if (!ModelState.IsValid) 
                    return View(movie);
                await _movieService.CreateMovieAsync(_mapper.Map<CreateMovieDto>(movie));
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                Console.WriteLine($"Error creating movie: {ex.Message}");
                return View(movie);
            }
        }

    }
}
