using AutoMapper;
using Journal.Application.Common.Mappings;
using Journal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Application.Teachers.Queries.GetTeacherInfo
{
    public class TeacherInfoVm : IMapWith<Teacher>
    {
        public Guid Id { get; set; }

        public string Surname { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string? Patronymic { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public byte[] Photo { get; set; }

        public string[] Subjects { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Teacher, TeacherInfoVm>()
                .ForMember(teacherInfoVm => teacherInfoVm.Id,
                    opt => opt.MapFrom(teacher => teacher.Id))
                .ForMember(teacherInfoVm => teacherInfoVm.Surname,
                    opt => opt.MapFrom(teacher => teacher.Surname))
                .ForMember(teacherInfoVm => teacherInfoVm.Name,
                    opt => opt.MapFrom(teacher => teacher.Name))
                .ForMember(teacherInfoVm => teacherInfoVm.Patronymic,
                    opt => opt.MapFrom(teacher => teacher.Patronymic))
                .ForMember(teacherInfoVm => teacherInfoVm.Phone,
                    opt => opt.MapFrom(teacher => teacher.Phone))
                .ForMember(teacherInfoVm => teacherInfoVm.Email,
                    opt => opt.MapFrom(teacher => teacher.Email))
                .ForMember(teacherInfoVm => teacherInfoVm.Photo,
                    opt => opt.MapFrom(teacher => teacher.Photo))
                .ForMember(teacherInfoVm => teacherInfoVm.Subjects,
                    opt => opt.MapFrom(teacher => teacher.TeacherSubjects
                        .Select(teacherSubject => teacherSubject.Subject.Name).ToArray()));
        }
    }
}
