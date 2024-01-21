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

namespace Journal.Application.StudentLessons.Queries.GetStudentLessonList
{
    public class GetStudentLessonListQueryHandler : IRequestHandler<GetStudentLessonsQuery, StudentLessonListVm>
    {
        private readonly IJournalDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetStudentLessonListQueryHandler(IJournalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<StudentLessonListVm> Handle(GetStudentLessonsQuery request, CancellationToken cancellationToken)
        {
            var studentLessons = await _dbContext.StudentLessons
                .Where(studentLessons => studentLessons.Lesson.TeacherId == request.TeacherId &&
                studentLessons.Lesson.SubjectId == request.SubjectId &&
                studentLessons.Lesson.Date >= DateTime.Today.AddDays(-60))
                .ProjectTo<StudentLessonDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new StudentLessonListVm { StudentLessons = studentLessons };
        }
    }
}
