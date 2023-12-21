using AutoMapper;
using AutoMapper.QueryableExtensions;
using Journal.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Application.TeacherGroups.Queries.GetTeacherGroupList
{
    public class GetTeacherGroupListQueryHandler : IRequestHandler<GetTeacherGroupListQuery, TeacherGroupListVm>
    {
        private readonly IJournalDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTeacherGroupListQueryHandler(IJournalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<TeacherGroupListVm> Handle(GetTeacherGroupListQuery request, CancellationToken cancellationToken)
        {
            var teacherGroups = await _dbContext.TeacherGroups
                .Where(teacherGroup => teacherGroup.TeacherId == request.TeacherId)
                .ProjectTo<TeacherGroupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new TeacherGroupListVm { TeacherGroups = teacherGroups };
        }
    }
}
