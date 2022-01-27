using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Izmainas.FileUploadService.Domain.Dtos;
using Izmainas.FileUploadService.Domain.Services;
using Npoi.Mapper;
using NPOI.SS.UserModel;

namespace Izmainas.FileUploadService.Services
{
    public class ExcelRepository : IExcelRepository
    {
        public async Task<List<StudentScheduleExcelDto>> GetAllSAsync(string path, int sheet) //GetStudentScheduleFromExcelAndSaveAsync
        {
            // TODO: save to local db
            var studentSchedule = await GetAllAsync<StudentScheduleExcelDto>(path, sheet);
            studentSchedule.ForEach(s =>
            {
                s.Lesson = s.Lesson.Substring(0, 1);
                s.Class = s.Class.Substring(0, s.Class.IndexOf(' ')).Replace(".", string.Empty).ToLower();
            });
            return studentSchedule;
        }

        public async Task<List<TeacherScheduleExcelDto>> GetAllTAsync(string path, int sheet)        
        {
            // TODO: save to local db
            var teacherSchedule = await GetAllAsync<TeacherScheduleExcelDto>(path, sheet);
            return teacherSchedule;
        }

        private async Task<List<T>> GetAllAsync<T>(string path, int sheet) where T : class
        {
            IWorkbook workbook;
            List<T> result = new(); // StudentScheduleExcelDto

            using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read)) //StudentScheduleFilePath
            {
                workbook = WorkbookFactory.Create(file);
            }

            var importer = new Mapper(workbook);
            var items = importer.Take<T>(sheet); //StudentScheduleExcelDto
            foreach (var item in items)
            {
                var row = item.Value;
                if (row is not null)
                {
                    result.Add(row);
                }                
            }
            return await Task.FromResult(result);
        }
    }
}