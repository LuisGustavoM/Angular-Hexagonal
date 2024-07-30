using Domain.Ports;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController(IMovieService movieService) : ControllerBase
    {
        private readonly IMovieService _movieService = movieService;


        [HttpGet]
        public async Task<IActionResult> GetAllMoviesAsync()
        {
            var movie = await _movieService.GetAllMoviesAsync();
            return Ok(movie);
        }


        [HttpPost]
        public async Task<IActionResult> PostMovie([FromBody] object a3)
        {
            var movie = await _movieService.GetAllMoviesAsync();
            return Ok(movie);
        }

    }
}
