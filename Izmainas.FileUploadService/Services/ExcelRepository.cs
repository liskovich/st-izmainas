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
    /// <summary>
    /// Class used for retrieving raw data from .xlsx spreadsheets
    /// </summary>
    public class ExcelRepository : IExcelRepository
    {
        /// <summary>
        /// Method used for retrieving all student data from spreadsheet
        /// </summary>
        /// <param name="path">Path to .xlsx file</param>
        /// <param name="sheet">Sheet index</param>
        /// <returns>Parsed data</returns>
        public async Task<List<StudentScheduleExcelDto>> GetAllSAsync(string path, int sheet)
        {
            var studentSchedule = await GetAllAsync<StudentScheduleExcelDto>(path, sheet);
            studentSchedule.ForEach(s =>
            {
                s.Lesson = s.Lesson.Substring(0, 1);
                s.Class = s.Class.Substring(0, s.Class.IndexOf(' ')).Replace(".", string.Empty).ToLower();
            });
            return studentSchedule;
        }

        /// <summary>
        /// Method used for retrieving all teacher data from spreadsheet
        /// </summary>
        /// <param name="path">Path to .xlsx file</param>
        /// <param name="sheet">Sheet index</param>
        /// <returns>Parsed data</returns>
        public async Task<List<TeacherScheduleExcelDto>> GetAllTAsync(string path, int sheet)        
        {
            var teacherSchedule = await GetAllAsync<TeacherScheduleExcelDto>(path, sheet);
            return teacherSchedule;
        }

        private async Task<List<T>> GetAllAsync<T>(string path, int sheet) where T : class
        {
            IWorkbook workbook;
            List<T> result = new();

            using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                workbook = WorkbookFactory.Create(file);
            }

            var importer = new Mapper(workbook);
            var items = importer.Take<T>(sheet);
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