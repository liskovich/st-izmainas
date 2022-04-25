using AutoMapper;
using Izmainas.API.Domain.Contracts.Client;
using Izmainas.API.Domain.Contracts.Client.Student;
using Izmainas.API.Domain.Services;
using Izmainas.API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.API.Services
{
    public class StudentScheduleService : IStudentScheduleService
    {
        private readonly IMapper _mapper;
        private readonly IScheduleImportRepository _scheduleImportRepository;
        private readonly INotesRepository _notesRepository;

        public StudentScheduleService(
            IMapper mapper,
            IScheduleImportRepository scheduleImportRepository, 
            INotesRepository notesRepository)
        {
            _mapper = mapper;
            _scheduleImportRepository = scheduleImportRepository;
            _notesRepository = notesRepository;
        }

        public async Task<StudentScheduleResponse> GetAsync(long date)
        {
            var dateTime = date.ToDateTime();
            //var day = (int)dateTime.DayOfWeek;
            var day = 1;

            var studentSchedules = await _scheduleImportRepository.GetStudentSchedule(day);
            var teacherSchedules = await _scheduleImportRepository.GetTeacherSchedule(day);
            var notes = await _notesRepository.GetAllNotesByDateAsync(date);

            //
            var scheduleResponse = new StudentScheduleResponse();
            //scheduleResponse.Classes.Add(new StClassDto().Lessons.Add(new StLessonDto().Rooms.Add(new StRoomDto())));

            //
            scheduleResponse.DayOfWeek = ((DayOfWeek)day).ToString();
            scheduleResponse.Date = date;
            scheduleResponse.Classes = new List<StClassDto>();

            var classesList = studentSchedules.Select(s => s.Class).Distinct();
            foreach (var c in classesList)
            {
                var stClass = new StClassDto()
                {
                    ClassNumber = c,
                    Lessons = new List<StLessonDto>()
                };

                var lessonsForClass = studentSchedules.Where(s => s.Class == c);
                foreach (var l in lessonsForClass)
                {
                    var stLesson = new StLessonDto()
                    {
                        LessonNumber = long.Parse(l.Lesson),
                        Rooms = new List<StRoomDto>()
                    };

                    var roomsForLesson = lessonsForClass
                        //.Where(r => r.Class == c)
                        .Where(r => r.Lesson == l.Lesson);

                    foreach (var r in roomsForLesson)
                    {
                        var separatedRoomSubject = ScheduleFormatHelpers.SeparateSubjectFromRoom(r.Subject);
                        var teachers = teacherSchedules
                            .Where(t => t.Class == c)
                            .Where(t => t.Lesson == l.Lesson);

                        var notesForRoom = notes
                            .Where(n => n.Class == c)
                            .Where(n => n.Lesson == int.Parse(l.Lesson))
                            .Where(n => n.CreatedDate == date);

                        // sus
                        //if (teachers.Count() < separatedRoomSubject.Rooms.Count())
                        //{
                        //    //
                        //}

                        for (int i = 0; i < separatedRoomSubject.Rooms.Count() - 1; i++)
                        {
                            var stRoom = new StRoomDto()
                            {
                                RoomNumber = separatedRoomSubject.Rooms[i],
                                Subject = separatedRoomSubject.Subjects[i],
                                TeacherName = teachers.ElementAt(i).TeacherName
                            };

                            // TODO: review teacher part (if multiple teachers)
                            //stRoom.TeacherName = teachers.FirstOrDefault().TeacherName;

                            // TODO: review if multiple notes possible
                            if (notesForRoom == null)
                            {
                                stRoom.Note = null;
                            }                          
                            var note = notesForRoom.FirstOrDefault();

                            if (note != null)
                            {
                                stRoom.Note = new StNoteDto()
                                {
                                    NoteId = note.Id,
                                    NoteText = note.NoteText,
                                    CreatedDate = note.CreatedDate
                                };
                            } 
                            else
                            {
                                stRoom.Note = null;
                            }
                            stLesson.Rooms.Add(stRoom);
                            // TODO: review why not all rooms filled
                        }


                    }
                    stClass.Lessons.Add(stLesson);
                }
                scheduleResponse.Classes.Add(stClass);
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
            return scheduleResponse;
        }

        
    }
}
