using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.FileUploadService.Domain.Constants
{
    public class ExcelTableNames
    {
        public static class Student
        {
            public const string Lesson = "Lesson";
            public const string Day = "Day";
            public const string Class = "Class";
            public const string Subject = "Subject";
        }
        
        public static class Teacher
        {
            public const string Lesson = "Lesson";
            public const string Day = "Day";
            public const string Class = "Class";
            public const string TeacherName = "TeacherName";
        }
    }
}