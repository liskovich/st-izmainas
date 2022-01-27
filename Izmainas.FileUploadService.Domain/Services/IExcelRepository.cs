using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Izmainas.FileUploadService.Domain.Dtos;

namespace Izmainas.FileUploadService.Domain.Services
{
    public interface IExcelRepository
    {
        Task<List<TeacherScheduleExcelDto>> GetAllTAsync(string path, int sheet);
        Task<List<StudentScheduleExcelDto>> GetAllSAsync(string path, int sheet);
    }
}