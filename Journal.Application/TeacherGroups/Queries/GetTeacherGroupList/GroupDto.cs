using AutoMapper;
using Journal.Application.Common.Mappings;
using Journal.Domain;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Application.TeacherGroups.Queries.GetTeacherGroupList
{
    public class GroupDto : IMapWith<Group>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Group, GroupDto>()
                .ForMember(groupDto => groupDto.Id,
                    opt => opt.MapFrom(group => group.Id))
                .ForMember(groupDto => groupDto.Name,
                    opt => opt.MapFrom(group => group.Name));
        }
    }
}
