using Domain.Entities;

namespace WebApi.DAOs.MovieDaos
{
    public class MovieUpdateDao
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DatePublication { get; set; }
        public Movie UpdateMovieEntidade(Movie movie)
        {
            movie.UpdateMovie(Name, DatePublication);
            return movie;
        }
    }
}

