using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Izmainas.FileUploadService.Data;
using Izmainas.FileUploadService.Domain.Entities;
using Izmainas.FileUploadService.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace Izmainas.FileUploadService.Services
{
    /// <summary>
    /// Class used for local storage of schedule changes
    /// </summary>
    public class SqliteRepository : ISqliteRepository
    {
        private readonly AppDbContext _context;

        public SqliteRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Clear student schedule local storage
        /// </summary>
        public void ClearStudentSchedulesAsync()
        {
            _context.StudentScehduleItems.RemoveRange();
            _context.SaveChanges();
        }

        public void ClearTeacherSchedulesAsync()
        {
            _context.TeacherScehduleItems.RemoveRange();
            _context.SaveChanges();
        }

        public async Task EnsureDatabaseCreated()
        {
            await _context.Database.EnsureCreatedAsync();
        }

        public async Task<bool> HasData()
        {
            return await _context.StudentScehduleItems.CountAsync() > 0
                && await _context.TeacherScehduleItems.CountAsync() > 0;
        }

        /// <summary>
        /// Method used for retrieving student schedule data from local storage
        /// </summary>
        /// <returns>List of student schedule data objects</returns>
        public async Task<List<StudentScheduleItem>> GetAllSAsync()
        {
            return await _context.StudentScehduleItems.ToListAsync();
        }

        /// <summary>
        /// Method used for retrieving teacher schedule data from local storage
        /// </summary>
        /// <returns>List of teacher schedule data objects</returns>
        public async Task<List<TeacherScheduleItem>> GetAllTAsync()
        {
            return await _context.TeacherScehduleItems.ToListAsync();
        }

        /// <summary>
        /// Method used for saving student schedule data into local storage
        /// </summary>
        /// <param name="items">Student data to save</param>
        public async Task InsertStudentSchedulesAsync(List<StudentScheduleItem> items)
        {
            await _context.StudentScehduleItems.AddRangeAsync(items);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Method used for saving teacher schedule data into local storage
        /// </summary>
        /// <param name="items">Teacher data to save</param>
        public async Task InsertTeacherSchedulesAsync(List<TeacherScheduleItem> items)
        {
            await _context.TeacherScehduleItems.AddRangeAsync(items);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}