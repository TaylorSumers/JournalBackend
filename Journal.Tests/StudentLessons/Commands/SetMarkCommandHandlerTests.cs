using Journal.Application.Common.Exceptions;
using Journal.Application.StudentLessons.Commands.SetMark;
using Journal.Tests.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Journal.Tests.StudentLessons.Commands
{
    public class SetMarkCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task SetMarkCommandHandler_Success()
        {
            // Arrange
            var handler = new SetMarkCommandHandler(context);
            var updatedMarkId = Guid.Parse("33f94fb4-7b7d-4f2f-bb20-e1742a1791d2");

            // Act
            await handler.Handle(new SetMarkCommand
            {
                StudentLessonId = JournalContextFactory.studentLessonIdForUpdate,
                MarkId = updatedMarkId
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await context.StudentLessons.SingleOrDefaultAsync(studentLesson =>
            studentLesson.Id == JournalContextFactory.studentLessonIdForUpdate &&
            studentLesson.MarkId == updatedMarkId));
        }

        [Fact]
        public async Task SetMarkCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new SetMarkCommandHandler(context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new SetMarkCommand
                {
                    StudentLessonId = Guid.NewGuid(),
                    MarkId = Guid.NewGuid()
                }, CancellationToken.None));
        }
    }
}
