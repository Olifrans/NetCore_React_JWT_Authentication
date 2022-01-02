using NetCoreReactJwt.Domain.Entities;

namespace NetCoreReactJwt.BusinessManager.Interfaces
{
    public interface ISchedulingBusinessManager
    {
        Task DeleteScheduleAsync(int id);
        Task<IEnumerable<Scheduling>> GetScheduleAsync();
        Task<Scheduling> GetSchedulesIdAsync(int id);
        Task<Scheduling> InsertSchedulesAsync(Scheduling schedule);
        Task<Scheduling> UpdateSchedulesAsync(Scheduling schedule);
    }
}
