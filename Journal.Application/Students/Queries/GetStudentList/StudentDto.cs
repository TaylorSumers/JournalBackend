using AutoMapper;
using Journal.Application.Common.Mappings;
using Journal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Application.Students.Queries.GetStudentList
{
    public class StudentDto : IMapWith<Student>
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Student, StudentDto>()
                .ForMember(studentDto => studentDto.Id,
                    opt => opt.MapFrom(student => student.Id))
                .ForMember(studentDto => studentDto.FullName,
                    opt => opt.MapFrom(student => $"{student.Surname} {student.Name}"));
        }
    }
}
