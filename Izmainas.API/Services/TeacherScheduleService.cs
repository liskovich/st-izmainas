using Izmainas.API.Domain.Contracts.Client.Teacher;
using Izmainas.API.Domain.Services;
using Izmainas.API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.API.Services
{
    /// <summary>
    /// Class responsible for getting all Teacher schedule data from database and transforming it into API response
    /// </summary>
    public class TeacherScheduleService : ITeacherScheduleService
    {
        private readonly IScheduleImportRepository _scheduleImportRepository;
        private readonly INotesRepository _notesRepository;

        public TeacherScheduleService(
            IScheduleImportRepository scheduleImportRepository, 
            INotesRepository notesRepository)
        {
            _scheduleImportRepository = scheduleImportRepository;
            _notesRepository = notesRepository;
        }

        /// <summary>
        /// Method used for response object generation (Show schedule changes for teachers in the webpage) - SHOWS ONLY THOSE TEACHERS WHO HAVE ANY CHANGES
        /// </summary>
        /// <param name="date">Date to generate for</param>
        /// <returns>Teacher schedule response object</returns>
        public async Task<TeacherScheduleResponse> GetAsync(long date)
        {
            var dateTime = date.ToDateTime();
            var day = (int)dateTime.DayOfWeek + 1;
            //var day = 1;

            var studentSchedules = await _scheduleImportRepository.GetStudentSchedule(day);
            var teacherSchedules = await _scheduleImportRepository.GetTeacherSchedule(day);
            var notes = await _notesRepository.GetAllNotesByDateAsync(date);

            var scheduleResponse = new TeacherScheduleResponse();
            var data = new Datas();
            
            data.DayOfWeek = ((DayOfWeek)day).ToString();
            data.Date = date;
            data.Teachers = new List<TcTeacherDto>();

            var teacherList = teacherSchedules.Select(t => t.TeacherName).Distinct();

            foreach (var c in teacherList)
            {
                var stTeacher = new TcTeacherDto()
                {
                    TeacherName = c,
                    Lessons = new List<TcLessonDto>()
                };

                var lessonsForTeacher = teacherSchedules.Where(t => t.TeacherName == c);
                foreach (var l in lessonsForTeacher)
                {
                    var rooms = new List<string>();
                    var stLesson = new TcLessonDto()
                    {
                        LessonNumber = long.Parse(l.Lesson),
                        Class = l.Class,
                    };

                    var roomForTeacher = studentSchedules
                        .Where(s => s.Lesson == l.Lesson)
                        .Where(s => s.Class == l.Class);

                    var noteForRoom = notes
                            .Where(n => n.Class == l.Class)
                            .Where(n => n.Lesson == int.Parse(l.Lesson))
                            .Where(n => n.CreatedDate == date).FirstOrDefault();

                    if (noteForRoom != null)
                    {
                        stLesson.Note = new TcNoteDto
                        {
                            NoteId = noteForRoom.Id,
                            NoteText = noteForRoom.NoteText,
                            CreatedDate = noteForRoom.CreatedDate
                        };
                    }

                    if (roomForTeacher.Count() != 0)
                    {
                        foreach (var r in roomForTeacher)
                        {
                            var separatedRoomSubject = ScheduleFormatHelpers.SeparateSubjectFromRoom(r.Subject);;

                            var room = separatedRoomSubject.Rooms[0];
                            rooms.Add(room);
                        }

                        stLesson.Room = rooms[0]; 
                    }

                    if (stLesson.Note != null)
                    {
                        stTeacher.Lessons.Add(stLesson);
                    }
                }

                if (stTeacher.Lessons.Count != 0)
                {
                    data.Teachers.Add(stTeacher);
                }
            }

            scheduleResponse.Datas = data;
            return scheduleResponse;
        }
    }
}
