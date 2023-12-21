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

namespace Journal.Application.StudentLessons.Commands.SetMark
{
    public class SetMarkCommandHandler : IRequestHandler<SetMarkCommand>
    {
        private readonly IJournalDbContext _dbContext;

        public SetMarkCommandHandler(IJournalDbContext dbContext) => _dbContext = dbContext;

        public async Task Handle(SetMarkCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.StudentLessons.FirstOrDefaultAsync(studentLesson =>
                studentLesson.Id == request.StudentLessonId, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(StudentLesson), request.StudentLessonId);
            }

            entity.MarkId = request.MarkId;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
