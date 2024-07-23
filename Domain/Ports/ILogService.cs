using Domain.Entities;

namespace Domain.Ports
{
    public interface ILogService
    {
        Task<IEnumerable<Log>> GetAllLogsAsync();
        Task<Log> AddNewLog(Log log);
    }
}
