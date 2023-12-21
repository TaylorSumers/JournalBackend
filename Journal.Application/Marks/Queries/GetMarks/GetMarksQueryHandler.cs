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

namespace Journal.Application.Marks.Queries.GetMarks
{
    public class GetMarksQueryHandler : IRequestHandler<GetMarksQuery, MarkListVm>
    {
        private readonly IJournalDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMarksQueryHandler(IJournalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<MarkListVm> Handle(GetMarksQuery request, CancellationToken cancellationToken)
        {
            var marks = await _dbContext.Marks
                .ProjectTo<MarkDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new MarkListVm { Marks = marks };
        }
    }
}
