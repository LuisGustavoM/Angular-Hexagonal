using Domain.Entities;
using Infra.Data.Context;

namespace WebApi.Config
{
    public static class DataInitializer
    {
        public static void InitializeData(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

            context?.Database.EnsureCreated();

            var listMovies = GetInitialMoviesData();

            context?.Movie.AddRange(listMovies);
            context?.SaveChanges();
        }

        private static List<Movie> GetInitialMoviesData()
        {
            return
            [
                Movie.Create("Deadpool & Wolverine", new DateTime(2024, 7, 25)),
                Movie.Create("Percy Jackson e o Ladrão de Raios", new DateTime(2010, 2, 12)),
                Movie.Create("The Shawshank Redemption", new DateTime(1994, 9, 22)),
                Movie.Create("The Godfather", new DateTime(1972, 3, 24)),
                Movie.Create("The Dark Knight", new DateTime(2008, 7, 18)),
                Movie.Create("Pulp Fiction", new DateTime(1994, 10, 14)),
                Movie.Create("Forrest Gump", new DateTime(1994, 7, 6)),
                Movie.Create("Inception", new DateTime(2010, 7, 16)),
                Movie.Create("Fight Club", new DateTime(1999, 10, 15)),
                Movie.Create("The Matrix", new DateTime(1999, 3, 31))
            ];
        }
    }
}

