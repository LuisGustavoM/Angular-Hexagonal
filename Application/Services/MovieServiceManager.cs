using Domain.Entities;
using Domain.Ports;

namespace Application.Services
{
    public class MovieServiceManager(
        IEmailService emailAdapter,IMovieRepository movieRepository) : IMovieService
    {
        private readonly IEmailService _emailAdapter = emailAdapter;
        private readonly IMovieRepository _movieRepository = movieRepository;

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            var movies = await _movieRepository.GetAll();
            return movies;
        }

        public async Task<Movie> UpdateMovieAsync(Movie movie)
        {
            var userUpdated = await _movieRepository.Update(movie);
            _emailAdapter.SendEmail("teste@teste.com", "teste@email.com", "Movie was updated with sucess...", "Updated movie");
            return userUpdated;
        }

        public async Task DeleteMovieAsync(Movie movie)
        {
            if (movie == null)
                throw new KeyNotFoundException(); // Lançar exceção quando o filme não for encontrado
            
            await _movieRepository.Delete(movie);
            _emailAdapter.SendEmail("teste@teste.com", "teste@email.com", "Movie was deleted with sucess...", "Deleted movie");
        }
        public async Task<Movie> AddNewMovieAsync(Movie movie)
        {
            await _movieRepository.Insert(movie);
            _emailAdapter.SendEmail("teste@teste.com", "teste@email.com", "Movie was included with sucess...", "Added movie");
            return movie;
        }

        public async Task<Movie> GetById(Guid id)
        {
            var movie = await _movieRepository.GetById(id) ?? throw new KeyNotFoundException("Movie not found.");  // Lançar exceção quando o filme não for encontrado
            return movie;
        }
    }
}