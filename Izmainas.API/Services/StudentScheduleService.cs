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
    /// <summary>
    /// Class responsible for getting all Student schedule data from database and transforming it into API response
    /// </summary>
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

        /// <summary>
        /// Method used for response object generation (Show schedule changes for students in the webpage) - SHOWS ONLY THOSE CLASSES THAT HAVE ANY CHANGES
        /// </summary>
        /// <param name="date">Date to generate for</param>
        /// <returns>Student schedule response object</returns>
        public async Task<StudentScheduleResponse> GetAsync(long date)
        {
            var dateTime = date.ToDateTime();
            var day = (int)dateTime.DayOfWeek + 1;

            var studentSchedules = await _scheduleImportRepository.GetStudentSchedule(day);
            var teacherSchedules = await _scheduleImportRepository.GetTeacherSchedule(day);
            var notes = await _notesRepository.GetAllNotesByDateAsync(date);

            var scheduleResponse = new StudentScheduleResponse();
            var data = new Data();
            
            data.DayOfWeek = ((DayOfWeek)day).ToString();
            data.Date = date;
            data.Classes = new List<StClassDto>();

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

                        for (int i = 0; i < separatedRoomSubject.Rooms.Count() - 1; i++)
                        {
                            var stRoom = new StRoomDto()
                            {
                                RoomNumber = separatedRoomSubject.Rooms[i],
                                Subject = separatedRoomSubject.Subjects[i],
                                TeacherName = teachers.ElementAt(i).TeacherName
                            };

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
                                stLesson.Rooms.Add(stRoom);

                            }
                            else
                            {
                                stRoom.Note = null;
                            }
                        }                        
                    }

                    if (stLesson.Rooms.Count != 0)
                    {
                        stClass.Lessons.Add(stLesson);
                    }
                }

                if (stClass.Lessons.Count != 0)
                {
                    data.Classes.Add(stClass);
                }
            }

            scheduleResponse.Data = data;
            return scheduleResponse;
        }

        /// <summary>
        /// Method used for response object generation (Show schedule changes for students in the webpage)
        /// </summary>
        /// <param name="date">Date to generate for</param>
        /// <returns>Student schedule response object</returns>
        public async Task<StudentScheduleResponse> GetFullAsync(long date)
        {
            var dateTime = date.ToDateTime();
            var day = (int)dateTime.DayOfWeek + 1;

            var studentSchedules = await _scheduleImportRepository.GetStudentSchedule(day);
            var teacherSchedules = await _scheduleImportRepository.GetTeacherSchedule(day);
            var notes = await _notesRepository.GetAllNotesByDateAsync(date);

            var scheduleResponse = new StudentScheduleResponse();
            var data = new Data();
            
            data.DayOfWeek = ((DayOfWeek)day).ToString();
            data.Date = date;
            data.Classes = new List<StClassDto>();

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

                        for (int i = 0; i < separatedRoomSubject.Rooms.Count() - 1; i++)
                        {
                            var stRoom = new StRoomDto()
                            {
                                RoomNumber = separatedRoomSubject.Rooms[i],
                                Subject = separatedRoomSubject.Subjects[i],
                                TeacherName = teachers.ElementAt(i).TeacherName
                            };

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
                        }
                    }
                    stClass.Lessons.Add(stLesson);
                }
                data.Classes.Add(stClass);
            }

            scheduleResponse.Data = data;
            return scheduleResponse;
        }
    }
}
