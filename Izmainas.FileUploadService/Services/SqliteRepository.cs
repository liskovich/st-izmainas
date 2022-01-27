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
    public class SqliteRepository : ISqliteRepository
    {
        private readonly AppDbContext _context;

        public SqliteRepository(AppDbContext context)
        {
            _context = context;
        }

        public void ClearStudentSchedulesAsync()
        {
            // TODO: review remove method
            _context.StudentScehduleItems.RemoveRange();
            _context.SaveChanges();
        }

        public void ClearTeacherSchedulesAsync()
        {
            // TODO: review remove method
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

        public async Task<List<StudentScheduleItem>> GetAllSAsync()
        {
            return await _context.StudentScehduleItems.ToListAsync();
        }

        public async Task<List<TeacherScheduleItem>> GetAllTAsync()
        {
            return await _context.TeacherScehduleItems.ToListAsync();
        }

        public async Task InsertStudentSchedulesAsync(List<StudentScheduleItem> items)
        {
            // TODO: make sure to call save
            await _context.StudentScehduleItems.AddRangeAsync(items);
            await _context.SaveChangesAsync();
        }

        public async Task InsertTeacherSchedulesAsync(List<TeacherScheduleItem> items)
        {
            // TODO: make sure to call save
            await _context.TeacherScehduleItems.AddRangeAsync(items);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}