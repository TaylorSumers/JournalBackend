using AutoMapper;
using Journal.Application.Common.Mappings;
using Journal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Application.Marks.Queries.GetMarks
{
    public class MarkDto : IMapWith<Mark>
    {
        public Guid Id { get; set; }

        public string ShortName { get; set; }

        public string FullName { get; set; }

        public void Mapping (Profile profile)
        {
            profile.CreateMap<Mark, MarkDto>()
                .ForMember(markDto => markDto.Id,
                    opt => opt.MapFrom(mark => mark.Id))
                .ForMember(markDto => markDto.ShortName,
                    opt => opt.MapFrom(mark => mark.ShortName))
                .ForMember(markDto => markDto.FullName,
                    opt => opt.MapFrom(mark => mark.FullName));
        }
    }
}
