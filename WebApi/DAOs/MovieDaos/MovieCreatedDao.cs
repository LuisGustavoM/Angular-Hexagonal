using Domain.Entities;

namespace WebApi.DAOs.MovieDaos
{
    public class MovieCreatedDao
    {
        public string Name { get; set; }
        public DateTime DatePublication { get; set; }
        public Movie CreateMovieEntidade()
        {
            return Movie.Create(Name, DatePublication);
        }
    }
}

