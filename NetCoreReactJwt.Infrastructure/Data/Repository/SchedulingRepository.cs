using Microsoft.EntityFrameworkCore;
using NetCoreReactJwt.BusinessManager.Interfaces;
using NetCoreReactJwt.Domain.Entities;

namespace NetCoreReactJwt.Infrastructure.Data.Repository
{
    public class SchedulingRepository : ISchedulingRepository
    {
        private readonly ContextDBConexao _context;
        public SchedulingRepository(ContextDBConexao context)
        {
            this._context = context;
        }

        public async Task DeleteScheduleAsync(int id)
        {
            var scheduleConsult = await _context.Schedules.FindAsync(id);
            _context.Schedules.Remove(scheduleConsult);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Scheduling>> GetScheduleAsync()
        {
            return await _context.Schedules.AsNoTracking().ToListAsync();  //AsNoTracking ganho de perfomace
        }

        public async Task<Scheduling> GetSchedulesIdAsync(int id)
        {
            return await _context.Schedules.SingleOrDefaultAsync(c => c.Id == id); //select top dois no BD
            //return await _gestaoEscolar.Alunos.FindAsync(id); //FindAsync ganho de perfomace, porém não permite fazer Join na base de dados

        }

        public async Task<Scheduling> InsertSchedulesAsync(Scheduling schedule)
        {
            await _context.Schedules.AddAsync(schedule);
            await _context.SaveChangesAsync();
            return schedule;
        }

        public async Task<Scheduling> UpdateSchedulesAsync(Scheduling schedule)
        {
            var scheduleConsult = await _context.Schedules.FindAsync(schedule.Id);
            if (scheduleConsult == null)
            {
                return null; //Not Found
            }           
            _context.Entry(scheduleConsult).CurrentValues.SetValues(schedule);
            //_context.Schedules.Update(alunoConsultado);
            await _context.SaveChangesAsync();
            return scheduleConsult;
        }
    }
}




//https://www.youtube.com/watch?v=FSUa8Vd-td0