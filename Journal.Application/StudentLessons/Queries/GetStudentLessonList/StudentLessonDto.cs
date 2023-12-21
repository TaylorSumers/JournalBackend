using AutoMapper;
using Journal.Application.Common.Mappings;
using Journal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Application.StudentLessons.Queries.GetStudentLessonList
{
    public class StudentLessonDto : IMapWith<StudentLesson>
    {
        public Guid StudentLessonId { get; set; }
        public Guid StudentId { get; set; }
        public Guid LessonId { get; set; }
        public DateTime LessonDate { get; set; }
        public Guid MarkId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<StudentLesson, StudentLessonDto>()
                .ForMember(studentLessonDto =>  studentLessonDto.StudentLessonId,
                    opt => opt.MapFrom(studentLesson => studentLesson.Id))
                .ForMember(studentLessonDto => studentLessonDto.StudentId,
                    opt => opt.MapFrom(studentLesson => studentLesson.StudentId))
                .ForMember(studentLessonDto => studentLessonDto.LessonId,
                    opt => opt.MapFrom(studentLesson => studentLesson.LessonId))
                .ForMember(studentLessonDto => studentLessonDto.LessonDate,
                    opt => opt.MapFrom(studentLesson => studentLesson.Lesson.Date))
                .ForMember(studentLessonDto => studentLessonDto.MarkId,
                    opt => opt.MapFrom(studentLesson => studentLesson.MarkId));
        }
    }
}
