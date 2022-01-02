using NetCoreReactJwt.BusinessManager.Interfaces;
using NetCoreReactJwt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreReactJwt.BusinessManager.Implementation
{
    public class SchedulingBusinessManager : ISchedulingBusinessManager
    {
        private readonly ISchedulingRepository _scheduling;
        public SchedulingBusinessManager(ISchedulingRepository scheduling)
        {
            this._scheduling = scheduling;
        }

        public async Task DeleteScheduleAsync(int id)
        {
             await _scheduling.DeleteScheduleAsync(id);
        }

        public async Task<IEnumerable<Scheduling>> GetScheduleAsync()
        {
            return await _scheduling.GetScheduleAsync();
        }

        public async Task<Scheduling> GetSchedulesIdAsync(int id)
        {
            return await _scheduling.GetSchedulesIdAsync(id);
        }

        public async Task<Scheduling> InsertSchedulesAsync(Scheduling auth)
        {
            return await _scheduling.InsertSchedulesAsync(auth);
        }

        public async Task<Scheduling> UpdateSchedulesAsync(Scheduling auth)
        {
            return await _scheduling.UpdateSchedulesAsync(auth);
        }
    }
}
