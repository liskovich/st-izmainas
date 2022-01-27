// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Izmainas.API.Domain.Abstractions;
// using Izmainas.API.Domain.Models;
// using Microsoft.EntityFrameworkCore;

// namespace Izmainas.API.Data.Repositories
// {
//     public class ScheduleRepository : IScheduleRepository
//     {
//         private readonly AppDbContext _context;

//         public ScheduleRepository(AppDbContext context)
//         {
//             _context = context;
//         }

//         public async Task<Schedule> GetAsync(Guid id)
//         {
//             return await _context.Schedules.FindAsync(id);
//         }

//         public async Task<List<Schedule>> GetAllAsync()
//         {
//             return await _context.Schedules.ToListAsync();
//         }

//         public async Task<Schedule> GetByDate(DateTime date)
//         {
//             return await _context.Schedules
//                 .Where(s => s.Date == ((DateTimeOffset)date).ToUnixTimeSeconds())
//                 .FirstOrDefaultAsync();
//         }

//         public async Task CreateAsync(Schedule item)
//         {
//             await _context.Schedules.AddAsync(item);
//         }

//         public void Update(Schedule item)
//         {
//             _context.Schedules.Update(item);
//         }

//         public async Task DeleteAsync(Guid id)
//         {
//             var entity = await _context.Schedules.FindAsync(id);
//             _context.Schedules.Remove(entity);
//         }

//         public async Task<bool> SaveChangesAsync()
//         {
//             return (await _context.SaveChangesAsync() >= 0);
//         }
//     }
// }