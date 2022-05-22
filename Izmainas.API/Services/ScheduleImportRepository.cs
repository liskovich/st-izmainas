using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Izmainas.API.Datasource;
using Izmainas.API.Domain.Entities;
using Izmainas.API.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace Izmainas.API.Services
{
    /// <summary>
    /// Internal service used to operate with Imported schedule in persistance level
    /// </summary>
    public class ScheduleImportRepository : IScheduleImportRepository
    {
        private readonly AppDbContext _context;

        public ScheduleImportRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method used for deleting all student schedules from database
        /// </summary>
        public async Task ClearStudentSchedules()
        {
            _context.StudentItems.RemoveRange(await GetStudentSchedule());
            await _context.SaveChangesAsync();            
        }

        /// <summary>
        /// Method used for deleting all teacher schedules from database
        /// </summary>
        public async Task ClearTeacherSchedules()
        {
            _context.TeacherItems.RemoveRange(await GetTeacherSchedule());
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Method used for retrieving all student schedules from database by day
        /// </summary>
        /// <param name="day">Identifier for student schedule lookup</param>
        /// <returns>A list of student schedules</returns>
        public async Task<IEnumerable<StudentScheduleItem>> GetStudentSchedule([Optional] int day)
        {
            if (day != 0)
            {
                return await _context.StudentItems.Where(i => i.Day == day).ToListAsync();                
            }
            return await _context.StudentItems.ToListAsync();
        }

        /// <summary>
        /// Method used for retrieving all teacher schedules from database by day
        /// </summary>
        /// <param name="day">Identifier for teacher schedule lookup</param>
        /// <returns>A list of teacher schedules</returns>
        public async Task<IEnumerable<TeacherScheduleItem>> GetTeacherSchedule([Optional] int day)
        {
            if (day != 0)
            {
                return await _context.TeacherItems.Where(i => i.Day == day).ToListAsync();                
            }
            return await _context.TeacherItems.ToListAsync();
        }

        /// <summary>
        /// Method used to populate database with imported student schedules
        /// </summary>
        /// <param name="items">Imported student schedule data to save</param>
        public async Task PopulateStudentSchedule(IEnumerable<StudentScheduleItem> items)
        {
            await _context.StudentItems.AddRangeAsync(items);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Method used to populate database with imported teacher schedules
        /// </summary>
        /// <param name="items">Imported teacher schedule data to save</param>
        public async Task PopulateTeacherSchedule(IEnumerable<TeacherScheduleItem> items)
        {
            await _context.TeacherItems.AddRangeAsync(items);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Save changes made to database
        /// </summary>
        /// <returns>Operation result (bool)</returns>
        /// <remarks>It is necessary to call this method on all operations that mutate data</remarks>
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}