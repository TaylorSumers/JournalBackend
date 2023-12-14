using AutoMapper;
using Journal.Application.Common.Mappings;
using Journal.Core;
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
        public DateTime LessonDate { get; set; }
        public Guid MarkId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<StudentLesson, StudentLessonDto>()
                .ForMember(studentLessonVm =>  studentLessonVm.StudentLessonId,
                    opt => opt.MapFrom(studentLesson => studentLesson.Id))
                .ForMember(studentLessonVm => studentLessonVm.StudentId,
                    opt => opt.MapFrom(studentLesson => studentLesson.StudentId))
                .ForMember(studentLessonVm => studentLessonVm.LessonDate,
                    opt => opt.MapFrom(studentLesson => studentLesson.Lesson.Date))
                .ForMember(studentLessonVm => studentLessonVm.MarkId,
                    opt => opt.MapFrom(studentLesson => studentLesson.MarkId));
        }
    }
}
