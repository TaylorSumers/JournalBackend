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

namespace Journal.Application.Students.Queries.GetStudentList
{
    public class GetStudentListQueryHandler : IRequestHandler<GetStudentListQuery, StudentListVm>
    {
        private IMapper _mapper;
        private IJournalDbContext _dbContext;

        public GetStudentListQueryHandler(IMapper mapper, IJournalDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<StudentListVm> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var students = await _dbContext.Students
                .Where(student => student.GroupId == request.GroupId)
                .ProjectTo<StudentDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new StudentListVm { Students = students };
        }
    }
}
