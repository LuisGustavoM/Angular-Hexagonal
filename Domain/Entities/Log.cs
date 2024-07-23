namespace Domain.Entities
{
    public sealed class Log
    {
        public Guid LogId { get; private set; }
        public string? Message { get; private set; }
        public DateTime Date { get; private set; }
        public static Log Create(string message)
        {
            return new Log()
            {
                LogId = Guid.NewGuid(),
                Message = message,
                Date = DateTime.Now
            };
        }
    }
}
