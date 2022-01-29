using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Izmainas.API.Data;
using Izmainas.API.Domain.Entities;
using Izmainas.API.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace Izmainas.API.Services
{
    public class ScheduleImportRepository : IScheduleImportRepository
    {
        private readonly AppDbContext _context;

        public ScheduleImportRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task ClearStudentSchedules()
        {
            // TODO: review clear method
            _context.StudentItems.RemoveRange(await GetStudentSchedule());
            await _context.SaveChangesAsync();            
        }

        public async Task ClearTeacherSchedules()
        {
            // TODO: review clear method
            _context.TeacherItems.RemoveRange(await GetTeacherSchedule());
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<StudentScheduleItem>> GetStudentSchedule([Optional] int day)
        {
            // TODO: check optional parameter specific
            if (day != 0)
            {
                return await _context.StudentItems.Where(i => i.Day == day).ToListAsync();                
            }
            return await _context.StudentItems.ToListAsync();
        }

        public async Task<IEnumerable<TeacherScheduleItem>> GetTeacherSchedule([Optional] int day)
        {
            // TODO: check optional parameter specific
            if (day != 0)
            {
                return await _context.TeacherItems.Where(i => i.Day == day).ToListAsync();                
            }
            return await _context.TeacherItems.ToListAsync();
        }

        public async Task PopulateStudentSchedule(IEnumerable<StudentScheduleItem> items)
        {
            await _context.StudentItems.AddRangeAsync(items);
            await _context.SaveChangesAsync();
        }

        public async Task PopulateTeacherSchedule(IEnumerable<TeacherScheduleItem> items)
        {
            await _context.TeacherItems.AddRangeAsync(items);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}