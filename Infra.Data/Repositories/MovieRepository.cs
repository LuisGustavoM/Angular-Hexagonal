using Domain.Entities;
using Domain.Ports;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class MovieRepository(ApplicationDbContext context) : IMovieRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task Delete(Movie movie)
        {
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            return await _context.Movie.ToListAsync();
        }

        public async Task<Movie?> GetById(Guid id)
        {
            var movie = await _context.Movie.FirstOrDefaultAsync(c => c.Id == id);
            return movie;
        }

        public async Task<Movie> Insert(Movie movie)
        {
            await _context.AddAsync(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie> Update(Movie movie)
        {
            _context.Movie.Update(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

    }
}
