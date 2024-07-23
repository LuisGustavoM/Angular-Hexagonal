using Domain.Entities;

namespace Domain.Tests.Entities
{
    public class MovieTests
    {
        [Fact]
        public void Create_ValidParameters_ShouldCreateMovie()
        {
            // Arrange
            var name = "Capitão América: o Primeiro Vingador (1943 - 1945)";
            var datePublication = new DateTime(2011, 7, 29);

            // Act
            var movie = Movie.Create(name, datePublication);

            // Assert
            Assert.NotNull(movie);
            Assert.Equal(name, movie.Name);
            Assert.Equal(datePublication, movie.DatePublication);
            Assert.Equal(DateTime.Now.Date, movie.DateRegistration.Date); // Apenas comparando a data, sem considerar o horário
        }

        [Fact]
        public void UpdateMovie_ValidParameters_ShouldUpdateMovie()
        {
            // Arrange
            var name = "Capitã Marvel (1995)";
            var datePublication = new DateTime(2019, 3, 6);
            var movie = Movie.Create("OldName", new DateTime(2000, 1, 1));

            // Act
            movie.UpdateMovie(name, datePublication);

            // Assert
            Assert.Equal(name, movie.Name);
            Assert.Equal(datePublication, movie.DatePublication);
        }

        [Fact]
        public void Create_ShouldGenerateUniqueId()
        {
            // Arrange
            var name = "O Incrível Hulk";
            var datePublication = new DateTime(2008, 6, 13);

            // Act
            var movie1 = Movie.Create(name, datePublication);
            var movie2 = Movie.Create(name, datePublication);

            // Assert
            Assert.NotEqual(movie1.Id, movie2.Id);
        }
    }
}
