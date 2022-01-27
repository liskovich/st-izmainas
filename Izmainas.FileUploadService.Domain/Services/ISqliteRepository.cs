using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Izmainas.FileUploadService.Domain.Entities;

namespace Izmainas.FileUploadService.Domain.Services
{
    public interface ISqliteRepository : IRepository<TeacherScheduleItem, StudentScheduleItem>
    {
        Task InsertTeacherSchedulesAsync(List<TeacherScheduleItem> items);
        Task InsertStudentSchedulesAsync(List<StudentScheduleItem> items);
        void ClearTeacherSchedulesAsync();
        void ClearStudentSchedulesAsync();
        
        Task<bool> SaveChangesAsync();
        Task EnsureDatabaseCreated();
        Task<bool> HasData();
    }
}