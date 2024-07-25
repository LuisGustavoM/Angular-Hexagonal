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
            var users = await _movieRepository.GetAll();
            return users;
        }

        public async Task<Movie> UpdateMovieAsync(Movie movie)
        {
            var userUpdated = await _movieRepository.Update(movie);
            _emailAdapter.SendEmail("teste@teste.com", "teste@email.com", "Movie was updated with sucess...", "Updated movie");
            return userUpdated;
        }

        public async Task DeleteMovieAsync(Guid id)
        {
            var movie = new Movie();
            await _movieRepository.Delete(movie);
            _emailAdapter.SendEmail("teste@teste.com", "teste@email.com", "Movie was deleted with sucess...", "Deleted movie");
        }
        public async Task<Movie> AddNewMovieAsync(Movie movie)
        {
            await _movieRepository.Insert(movie);
            _emailAdapter.SendEmail("teste@teste.com", "teste@email.com", "Movie was included with sucess...", "Added movie");
            return movie;
        }
    }
}