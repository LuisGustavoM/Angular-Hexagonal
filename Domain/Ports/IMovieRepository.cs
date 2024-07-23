using Domain.Entities;

namespace Domain.Ports
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAll();
        Task<Movie> Insert(Movie movie);
        Task<Movie> Update(Movie movie);
        Task<Movie> Delete(Guid id);
    }
}
