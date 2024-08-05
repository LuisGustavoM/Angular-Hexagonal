using Domain.Ports;
using Microsoft.AspNetCore.Mvc;
using WebApi.DAOs.MovieDaos;

namespace WebApi.Controllers
{
    /// <summary>
    /// Controller responsável por gerenciar operações relacionadas a filmes.
    /// </summary>
    /// <remarks>
    /// Construtor do MovieController.
    /// </remarks>
    /// <param name="movieService">Serviço de filmes injetado.</param>
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController(IMovieService movieService) : ControllerBase
    {
        private readonly IMovieService _movieService = movieService;

        /// <summary>
        /// Retorna todos os filmes cadastrados.
        /// </summary>
        /// <returns>Lista de filmes.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllMoviesAsync()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return Ok(movies);
        }

        /// <summary>
        /// Cadastrar novo filme.
        /// </summary>
        /// <param name="movieDto">Dados do filme a ser cadastrado.</param>
        /// <returns>Filme cadastrado.</returns>
        [HttpPost]
        public async Task<IActionResult> PostMovie([FromBody] MovieCreatedDao movieDto)
        {
            var movie = movieDto.CreateMovieEntidade();
            movie = await _movieService.AddNewMovieAsync(movie);
            return Ok(movie); ;
        }

        /// <summary>
        /// Editar filme existente.
        /// </summary>
        /// <param name="movieDao">Dados atualizados do filme.</param>
        /// <returns>Filme atualizado.</returns>
        [HttpPatch]
        public async Task<IActionResult> PatchMovie([FromBody] MovieUpdateDao movieDao)
        {
            var movie = await _movieService.GetById(movieDao.Id);
            var movieAtt = movieDao.UpdateMovieEntidade(movie);
            
            var response = await _movieService.UpdateMovieAsync(movieAtt);
            return Ok(response);
        }

        /// <summary>
        /// Excluir filme.
        /// </summary>
        /// <param name="id">ID do filme a ser excluído.</param>
        /// <returns>Resultado da exclusão.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(Guid id)
        {
            var movie = await _movieService.GetById(id);

            await _movieService.DeleteMovieAsync(movie);
            return Ok();
        }
    }
}
