using Domain.Entities;

namespace Domain.Ports
{
    public interface ILogRepository
    {
        Task<IEnumerable<Log>> GetAll();
        Task<Log> Insert(Log log);
    }
}
