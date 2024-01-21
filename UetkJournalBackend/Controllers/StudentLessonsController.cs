using Journal.Application.StudentLessons.Commands.SetMark;
using Journal.Application.StudentLessons.Queries.GetStudentLessonList;
using Journal.Domain;
using Microsoft.AspNetCore.Mvc;

namespace UetkJournal.WebApi.Controllers
{
    public class StudentLessonsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<StudentLessonListVm>> GetAll(Guid teacherId, Guid subjectId, Guid groupId)
        {
            var query = new GetStudentLessonsQuery
            {
                TeacherId = teacherId,
                SubjectId = subjectId,
                GroupId = groupId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPut]
        public async Task<ActionResult> SetMark(Guid studentLessonId, Guid markId)
        {
            var command = new SetMarkCommand
            {
                StudentLessonId = studentLessonId,
                MarkId = markId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
