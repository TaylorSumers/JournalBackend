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
    public class TeacherGroupDto : IMapWith<TeacherGroup>
    {
        public GroupDto Group { get; set; }

        public SubjectDto Subject { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TeacherGroup, TeacherGroupDto>()
            .ForMember(teacherGroupDto => teacherGroupDto.Group,
                opt => opt.MapFrom(teacherGroup => teacherGroup.Group))
            .ForMember(teacherGroupDto => teacherGroupDto.Subject,
                opt => opt.MapFrom(teacherGroup => teacherGroup.Subject));
        }
    }
}
