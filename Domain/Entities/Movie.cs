namespace Domain.Entities
{
    public sealed class Movie
    {
        public Guid Id { get; private set; }
        public string? Name { get; private set; }
        public DateTime DatePublication { get; private set; }
        public DateTime DateRegistration { get; private set; }
        public void UpdateMovie(string name, DateTime datePublication)
        {
            Name = name;
            DatePublication = datePublication;
        }
        public static Movie Create(string name, DateTime datePublication)
        {
            return new Movie()
            {
                Id = Guid.NewGuid(),
                Name = name,
                DatePublication = datePublication,
                DateRegistration = DateTime.Now
            };
        }
    }
}
