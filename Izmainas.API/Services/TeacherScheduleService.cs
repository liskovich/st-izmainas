using Izmainas.API.Domain.Contracts.Client.Teacher;
using Izmainas.API.Domain.Services;
using Izmainas.API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.API.Services
{
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

        public async Task<TeacherScheduleResponse> GetAsync(long date)
        {
            var dateTime = date.ToDateTime();
            var day = (int)dateTime.DayOfWeek + 1;
            //var day = 1;

            var studentSchedules = await _scheduleImportRepository.GetStudentSchedule(day);
            var teacherSchedules = await _scheduleImportRepository.GetTeacherSchedule(day);
            var notes = await _notesRepository.GetAllNotesByDateAsync(date);

            var scheduleResponse = new TeacherScheduleResponse();
            //scheduleResponse.Classes.Add(new StClassDto().Lessons.Add(new StLessonDto().Rooms.Add(new StRoomDto())));
            var data = new Datas();
            //
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

                    // kostilj
                    if (noteForRoom != null)
                    {
                        stLesson.Note = new TcNoteDto
                        {
                            NoteId = noteForRoom.Id,
                            NoteText = noteForRoom.NoteText,
                            CreatedDate = noteForRoom.CreatedDate
                        };
                    }

                    // kostilj
                    if (roomForTeacher.Count() != 0)
                    {
                        foreach (var r in roomForTeacher)
                        {
                            var separatedRoomSubject = ScheduleFormatHelpers.SeparateSubjectFromRoom(r.Subject);
                            //var teachers = teacherSchedules
                            //    .Where(t => t.Class == c)
                            //    .Where(t => t.Lesson == l.Lesson);

                            var room = separatedRoomSubject.Rooms[0];
                            rooms.Add(room);
                        }

                        stLesson.Room = rooms[0]; 
                    }

                    if (stLesson.Note != null)
                    {
                        stTeacher.Lessons.Add(stLesson);
                    }
                    //stClass.Lessons.Add(stLesson);
                }

                if (stTeacher.Lessons.Count != 0)
                {
                    data.Teachers.Add(stTeacher);
                }

                //data.Classes.Add(stClass);
            }


            //foreach (var studentSchedule in studentSchedules)
            //{
            //    var sClass = studentSchedule.Class;
            //    var sLessons = studentSchedule.Lesson;
            //    //var sDay = ((DayOfWeek)studentSchedule.Day).ToString();
            //    var sSubject = studentSchedule.Subject;
            //    var sId = studentSchedule.Id;
            //}
            //

            // implement method

            //throw new NotImplementedException();
            // some code
            scheduleResponse.Datas = data;
            return scheduleResponse;
        }
    }
}
