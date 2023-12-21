using Journal.Application.TeacherGroups.Queries.GetTeacherGroupList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UetkJournal.WebApi.Controllers
{
    public class GroupsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<TeacherGroupListVm>> GetAll(Guid teacherId)
        {
            var query = new GetTeacherGroupListQuery
            {
                TeacherId = teacherId 
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
