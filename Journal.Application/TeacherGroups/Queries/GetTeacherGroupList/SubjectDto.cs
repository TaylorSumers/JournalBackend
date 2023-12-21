using AutoMapper;
using Journal.Application.Common.Mappings;
using Journal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Application.TeacherGroups.Queries.GetTeacherGroupList
{
    public class SubjectDto : IMapWith<Subject>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Subject, SubjectDto>()
                .ForMember(subject => subject.Id,
                    opt => opt.MapFrom(subject => subject.Id))
                .ForMember(subject => subject.Name,
                    opt => opt.MapFrom(subject => subject.Name));
        }
    }
}
