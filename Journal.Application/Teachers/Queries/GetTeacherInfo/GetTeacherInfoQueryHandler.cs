using AutoMapper;
using Journal.Application.Common.Exceptions;
using Journal.Application.Interfaces;
using Journal.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Application.Teachers.Queries.GetTeacherInfo
{
    public class GetTeacherInfoQueryHandler : IRequestHandler<GetTeacherInfoQuery, TeacherInfoVm>
    {
        private IMapper _mapper;
        private IJournalDbContext _dbContext;

        public GetTeacherInfoQueryHandler(IMapper mapper, IJournalDbContext context)
        {
            _mapper = mapper;
            _dbContext = context;
        }

        public async Task<TeacherInfoVm> Handle(GetTeacherInfoQuery request, CancellationToken cancellationToken)
        {
            var teacher = await _dbContext.Teachers.FirstOrDefaultAsync(teacher => teacher.Login == request.Login && teacher.Password == request.Password);

            if (teacher == null)
            {
                throw new NotFoundException(nameof(Teacher), $"{request.Login} {request.Password}");
            }

            return _mapper.Map<TeacherInfoVm>(teacher);
        }
    }
}
