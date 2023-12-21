using Journal.Application.Students.Queries.GetStudentList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UetkJournal.WebApi.Controllers
{
    public class StudentsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<StudentListVm>> GetAll(Guid groupId)
        {
            var request = new GetStudentListQuery
            {
                GroupId = groupId
            };
            var vm = await Mediator.Send(request);
            return vm;
        }
    }
}
