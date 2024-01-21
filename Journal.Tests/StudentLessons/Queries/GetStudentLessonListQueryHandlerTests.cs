using AutoMapper;
using Journal.Application.StudentLessons.Queries.GetStudentLessonList;
using Journal.Domain;
using Journal.Tests.Common;
using Microsoft.IdentityModel.Tokens;
using Microsoft.SqlServer.Server;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Journal.Tests.StudentLessons.Queries
{
    [Collection("QueryCollection")]
    public class GetStudentLessonListQueryHandlerTests
    {
        private readonly JournalDbContext context;
        private readonly IMapper mapper;

        public GetStudentLessonListQueryHandlerTests(QueryTestFixture fixture)
        {
            context = fixture.context;
            mapper = fixture.mapper;
        }

        [Fact]
        public async void GetStudentLessonListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetStudentLessonListQueryHandler(context, mapper);

            // Act
            var result = await handler.Handle(
                new GetStudentLessonsQuery
                {
                    SubjectId = JournalContextFactory.subjectId,
                    GroupId = JournalContextFactory.groupId,
                    TeacherId = JournalContextFactory.teacherId
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<StudentLessonListVm>();
            result.StudentLessons.Count.ShouldBe(2);
        }
    }
}
